using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Firebase;
using Firebase.Auth;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;


public class FirebaseController : MonoBehaviour
{
    public InputField Email_InputField, Password_InputField;

    public GameObject NotificationMessage;

    public Text ErrorMessage;
    public Text ERROR; 

    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;

    void Start()
    {

        NotificationMessage.SetActive(false);
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                InitializeFirebase();

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    

    public void LoginUser()
    {
        //We first check if there are any empty input 
        if (string.IsNullOrEmpty(Email_InputField.text) && string.IsNullOrEmpty(Password_InputField.text))
        {
            showNotificationMessage("Fields Empty! Please Input All Details");
            return;
        }
        else if (string.IsNullOrEmpty(Email_InputField.text))
        {
            showNotificationMessage("Missing Email! ");
        }
        else if(string.IsNullOrEmpty(Password_InputField.text))
        {
            showNotificationMessage("Missing Password!");
        }

        //We call this function and have the input fields as arguments
        SignInUser(Email_InputField.text, Password_InputField.text);

    }

    public void SignUpUser()
    {
        //We check for any empty input fields
        if (string.IsNullOrEmpty(Email_InputField.text) && string.IsNullOrEmpty(Password_InputField.text))
        {
            showNotificationMessage("Fields Empty! Please Input All Details");
            return; 
        }
        else if (string.IsNullOrEmpty(Email_InputField.text))
        {
            showNotificationMessage("Missing Email! ");
        }
        else if (string.IsNullOrEmpty(Password_InputField.text))
        {
            showNotificationMessage("Missing Password!");
        }

        //We call the create user function and have the input fields as arguments
        CreateUser(Email_InputField.text, Password_InputField.text);
      
    }

    //In this function, the parameter is a string containing the error message
    public void showNotificationMessage(string message)
    {
        //We set our text to the message
        //And we open the NotificationPanel 
        //To display message
        ErrorMessage.text = message;
        NotificationMessage.SetActive(true);
    }

    public void CloseNotifPanel()
    {
        //We make our text empty
        //And close the Notification panel
        ErrorMessage.text = "";
        NotificationMessage.SetActive(false);
    }

    //This function is used to create a user and 
    //Takes two strings as parameters
    void CreateUser(string email, string password)
    {
        //Application connects with Firebase database and creates a user
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                //In case there are errors, we will extract
                //What error it is
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                foreach (Exception exception in task.Exception.Flatten().InnerExceptions)
                {
                    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
                    if (firebaseEx != null)
                    {
                        var errorCode = (AuthError)firebaseEx.ErrorCode;
                        showNotificationMessage(GetErrorMessage(errorCode));
                    }
                }
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            //Once user has been created successfully,
            //We will load the next scene
            SceneManager.LoadScene(sceneName: "Menu");
        });
    }
   
    //Function is used to sign in a user
    //And takes in two string parameters
    public void SignInUser(string email, string password)
    {
        //We connect to the Firebase and sign in the user
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }

            //We catch any errors that might occur
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);

                foreach (Exception exception in task.Exception.Flatten().InnerExceptions)
                {
                    Firebase.FirebaseException firebaseEx = task.Exception.GetBaseException() as Firebase.FirebaseException;
                    if (firebaseEx != null)
                    {
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                        string msg = Errormsg(GetErrorMessage(errorCode));
                        showNotificationMessage(msg); 
                        //showNotificationMessage(GetErrorMessage(errorCode));
                    }
                }
                return;
            }

            SceneManager.LoadScene(sceneName: "Menu");

            //We successfully sign in the user
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

        });

    } 

    //This function starts the Firebase connection
    void InitializeFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserId);
                // displayName = user.DisplayName ?? "";
                //emailAddress = user.Email ?? "";
                // photoUrl = user.PhotoUrl ?? "";

                //Once user signs in, we load the next scene
                SceneManager.LoadScene(sceneName: "Menu");
            }
        }
    }

    //This function recieves the error code as a parameter
    public static string GetErrorMessage(AuthError errorCode)
    {
        string message = "Login Failed!";

        //We use the switch case to know which 
        //Error occurred to let the user know
        switch (errorCode)
        {
            case AuthError.AccountExistsWithDifferentCredentials:
                message = "Account Not Exist";
                break;
            case AuthError.MissingPassword:
                message = "Password Missing";
                break;
            case AuthError.WrongPassword:
                message = "Incorrect Password";
                break;
            case AuthError.EmailAlreadyInUse:
                message = "Email is already in use";
                break;
            case AuthError.MissingEmail:
                message = "Email Missing";
                break;
            default:
                message = "Error Occurred";
                break;
        }
        return message;
    }

    public static string Errormsg(string message)
    {
        if(string.Compare(message, "Password Missing")==0)
        {
            message = ("Password Missing. ");
        }

        return message; 
    }

    //This user signs out a user 
    public void signOut(FirebaseAuth auth)
    {
        auth.SignOut();
        Debug.Log("Signing out user. ");
        return;
    }

    public void OnApplicationQuit()
    {
        signOut(auth); 
    }


}
