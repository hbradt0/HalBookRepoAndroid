using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using System.IO;
using Android.Widget;
using EmailReader;
using Android.Content;
using Android.Content.PM;
//using Tesseract.Droid;
using Android.Graphics;
using Android.Graphics.Drawables;
using Java.IO;
using Android.Provider;
using Android.Media;
using Android.Util;
using AndroidX.Core.Content;
using AndroidX.Core.App;
using Android;

namespace HalBookAppAndroid
{
    [Activity(Label = "Create Your Story", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]//Icon = "@drawable/ic_launcher"
    public class MainActivity : AppCompatActivity
    {
        //Text views
        public Android.Widget.TextView textView;
        public Android.Widget.TextView textView2;
        public Android.Widget.EditText editTextWrite;
        public Android.Widget.TextView textViewWrite;
        public Android.Widget.ImageView titleText;
        public Android.Widget.TextView storytextView;

        //Buttons
        public Android.Widget.Button Button1;
        public Android.Widget.ImageView Button2;
        public Android.Widget.Button Button3;
        public Android.Widget.Button Buttonbackyourstory;
        public Android.Widget.Button Buttonyourstoryscreen;
        public Android.Widget.Button ButtonyourstoryscreenUpload;
        public Android.Widget.Button ButtonDelete;
        public Android.Widget.Button ButtonDelete1Line;
        public AppCompatAutoCompleteTextView readInfo;
        public Android.Widget.ImageView imageView;
        public Android.Widget.Button ImageCalendar;
        int togglePicture;
        int textViewLocation = 0;
        int textViewLocation1 = 0;
        public Android.Widget.EditText editTextDateJournal;
        public Android.Widget.ImageView ShareTodoJournal;

        //TODO view
        public Android.Widget.EditText editTextTodo;
        public Android.Widget.EditText editTextDate;
        public Android.Widget.TextView textViewTodo;
        public Android.Widget.Button ButtonTodoList;
        public Android.Widget.Button ButtonTodoUpload;
        public Android.Widget.Button ButtonTodoDelete;
        public Android.Widget.Button ButtonTodoDelete1Line;
        public Android.Widget.Button ButtonbackTodo;
        public Android.Widget.ImageView ShareTodo;
        public Android.Widget.Button ReadHiddenJournal;

        //Date 
        public Android.Widget.ImageView ButtonDateShare;
        public Android.Widget.TextView editTextDateShare;

        //Button
        public Android.Widget.Button ButtonGoToEditPageStart;
        public Android.Widget.Button ButtonSaveEditPage;
        public Android.Widget.EditText EditJournal;
        public Android.Widget.Button ButtonBackEditPage;

        //Image view
        public Android.Widget.ImageView imagechoosephoto;
        public Android.Widget.Button ImagePageBack;
        public Android.Widget.ImageView ChoosePhoto;
        public Android.Widget.ImageView ChooseCameraPhoto;
        public Android.Widget.ImageView ButtonShareImagePage;
        public Android.Widget.Button savedImageButton;
        public Android.Widget.ImageView titletoggle;
        int toggletitle1 = 1;

        //Login page
        public Android.Widget.EditText loginemail;
        public Android.Widget.EditText loginpassword;
        public Android.Widget.ImageView submitbutton;
        public Android.Widget.TextView instructionsEmail;
        public Android.Widget.Button ButtonUploadBlobJournal;
        public Android.Widget.Button ButtonDownloadBlobJournal;
        public Android.Widget.Button ButtonDeleteBlobJournal;
        public Android.Widget.Button ButtonUploadBlobTodo;
        public Android.Widget.Button ButtonDownloadBlobTodo;
        public Android.Widget.Button ButtonDeleteBlobTodo;
        public Android.Widget.Button ButtonBackLoginPage;
        public Android.Widget.TextView textViewBlob;
        public Android.Widget.Button ViewBlob;
        int blobtoggle = 0;
        public static string str = "Blob ";


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            //Image view
            togglePicture = 0;
            imageView = FindViewById<ImageView>(Resource.Id.NewImage);
            imageView.SetImageResource(Resource.Drawable.blueflowers);
            //imageView.Click += ImageOnClick;

            //Initialize
            Button2 = FindViewById<ImageView>(Resource.Id.Image);
            textView = FindViewById<Android.Widget.TextView>(Resource.Id.bookText);
            Button1 = FindViewById<Android.Widget.Button>(Resource.Id.EmailPageButton);
            Buttonyourstoryscreen = FindViewById<Android.Widget.Button>(Resource.Id.yourstoryscreenbutton);
            titleText = FindViewById<Android.Widget.ImageView>(Resource.Id.titleText);
            textView2 = FindViewById<Android.Widget.TextView>(Resource.Id.Instructions);
            ButtonTodoList = FindViewById<Android.Widget.Button>(Resource.Id.TodoListButton);
            Button2 = FindViewById<ImageView>(Resource.Id.Image);
            ImageCalendar = FindViewById<Android.Widget.Button>(Resource.Id.ImageCalendar);

            ImageCalendar.Text = "Change Image";
            var fileName2 = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "image.jpg");
            if (System.IO.File.Exists(fileName2))
            {
                Bitmap bitmap = BitmapFactory.DecodeFile(fileName2);
                imageView.SetImageBitmap(bitmap);
            }
            else
            {
                imageView.SetImageResource(Resource.Drawable.blueflowers);
            }

            //Properties
            textView2.Text = "Click mail to share your story!";
            Button1.Text = "Click to Read";

            if (savedInstanceState != null)
                toggletitle1 = savedInstanceState.GetInt("toggletitle1", 0);
            if (toggletitle1 == 0)
            {
                titleText.SetImageResource(Resource.Drawable.MainTitlePic);
            }
            else
            {
                titleText.SetImageResource(Resource.Drawable.MainTitlePic1);
            }
            Buttonyourstoryscreen.Text = "Create your journal";

            ButtonTodoList.Text = "Create To Do List";

            if (savedInstanceState != null)
                textViewLocation = savedInstanceState.GetInt("textViewLocation", 0);

            if (savedInstanceState != null)
            {
                FireBaseRead.LoginEmail = savedInstanceState.GetString("LoginEmail");
                FireBaseRead.LoginPassword = savedInstanceState.GetString("LoginPassword");
                FireBaseRead.phoneID = savedInstanceState.GetString("phoneId");
            }

            //Clicks
            Button1.Click += Button1Click;
            Button2.Click += Button2Click;
            Buttonyourstoryscreen.Click += ButtonyourstoryscreenClick;
            ButtonTodoList.Click += ButtonTodoClick;
            ImageCalendar.Click += ButtonImageCalendarClick;

        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("textViewLocation", textViewLocation);
            outState.PutInt("textViewLocation1", textViewLocation1);
            outState.PutInt("toggletitle", toggletitle1);
            outState.PutString("LoginEmail", FireBaseRead.LoginEmail);
            outState.PutString("LoginPassword", FireBaseRead.LoginPassword);
            outState.PutString("phoneId", FireBaseRead.phoneID);
            base.OnSaveInstanceState(outState);
        }

        private void Button1Click(object sender, EventArgs eventArgs)
        {
            SetContentView(Resource.Layout.activity_user_main);
            //Initialize
            textView = FindViewById<Android.Widget.TextView>(Resource.Id.bookText);
            Button3 = FindViewById<Android.Widget.Button>(Resource.Id.back);
            var hiddenbutton = FindViewById<Android.Widget.Button>(Resource.Id.hiddenbutton);
            var hidemybuttontext = FindViewById<Android.Widget.EditText>(Resource.Id.hiddenbuttontext);
            var codeText = FindViewById<Android.Widget.TextView>(Resource.Id.codeText);
            ShareTodoJournal = FindViewById<Android.Widget.ImageView>(Resource.Id.todosharejournal);
            editTextDateJournal = FindViewById<Android.Widget.EditText>(Resource.Id.dayspriorjournal);
            editTextDateJournal.Hint = "0 days";
            ShareTodoJournal.SetImageResource(Resource.Drawable.share);

            var ButtonCreateSync = FindViewById<Android.Widget.Button>(Resource.Id.CloudSync);
            ButtonCreateSync.Text = "Login for Cloud";
            ButtonCreateSync.Click += ButtonCreateSyncCloud;

            //Properties with
            Button3.Text = "Back";
            textView.SetScrollContainer(true);
            textView.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            textView.Parent.RequestDisallowInterceptTouchEvent(false);
            textView.ScrollTo(0, textViewLocation);
            Button3.Click += Button3Click;
            String texty = EmailFileRead.ReadText();
            textView.Text = texty;
            textViewLocation = textView.ScrollY;
            hiddenbutton.Text = "Code";
            hidemybuttontext.Hint = "type 'help'";

            String codesneeded = "";
            if (EmailFileRead.FileCountDays(EmailFileRead.fileName1, 1))
            {
                codesneeded = codesneeded + "\nstrcode1";
            }
            if (EmailFileRead.FileCountDays(EmailFileRead.fileName1, 7))
            {
                codesneeded = codesneeded + "\nstrcodexx10";
            }
            if (EmailFileRead.FileCountDays(EmailFileRead.fileName1, 14))
            {
                codesneeded = codesneeded + "\nstrcodex50";
            }
            if (EmailFileRead.FileCountDays(EmailFileRead.fileName1, 21))
            {
                codesneeded = codesneeded + "\nstrcodea100";
            }
            codeText.Text = "Codes Unlocked!!" + codesneeded;

            ShareTodoJournal.Click += ShareTodoJournalClick;
            //Clicks
            hiddenbutton.Click += hiddenbuttonclick;
        }

        private void Button1ClickStory(object sender, EventArgs eventArgs)
        {
            textViewLocation1 = storytextView.ScrollY;
            SetContentView(Resource.Layout.activity_user_main);
            //Initialize
            textView = FindViewById<Android.Widget.TextView>(Resource.Id.bookText);
            Button3 = FindViewById<Android.Widget.Button>(Resource.Id.back);
            var hiddenbutton = FindViewById<Android.Widget.Button>(Resource.Id.hiddenbutton);
            var hidemybuttontext = FindViewById<Android.Widget.EditText>(Resource.Id.hiddenbuttontext);
            var codeText = FindViewById<Android.Widget.TextView>(Resource.Id.codeText);
            ShareTodoJournal = FindViewById<Android.Widget.ImageView>(Resource.Id.todosharejournal);
            editTextDateJournal = FindViewById<Android.Widget.EditText>(Resource.Id.dayspriorjournal);
            editTextDateJournal.Hint = "0 days";
            ShareTodoJournal.SetImageResource(Resource.Drawable.share);

            //Properties with
            Button3.Text = "Back";
            textView.SetScrollContainer(true);
            textView.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            textView.Parent.RequestDisallowInterceptTouchEvent(false);
            textView.ScrollTo(0, textViewLocation);
            Button3.Click += Button3Click;
            String texty = EmailFileRead.ReadText();
            textView.Text = texty;
            textViewLocation = textView.ScrollY;
            hiddenbutton.Text = "Code";
            hidemybuttontext.Hint = "type 'help'";

            codeText.SetScrollContainer(true);
            codeText.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            codeText.Parent.RequestDisallowInterceptTouchEvent(false);

            String codesneeded = "";
            if (EmailFileRead.FileCountDays(EmailFileRead.fileName1, 1))
            {
                codesneeded = codesneeded + "\n" + EmailFileRead.CodeList[0];
            }
            if (EmailFileRead.FileCountDays(EmailFileRead.fileName1, 7))
            {
                codesneeded = codesneeded + "\n" + EmailFileRead.CodeList[1];
            }
            if (EmailFileRead.FileCountDays(EmailFileRead.fileName1, 14))
            {
                codesneeded = codesneeded + "\n" + EmailFileRead.CodeList[2];
            }
            if (EmailFileRead.FileCountDays(EmailFileRead.fileName1, 21))
            {
                codesneeded = codesneeded + "\n" + EmailFileRead.CodeList[3];
            }
            var ButtonCreateSync = FindViewById<Android.Widget.Button>(Resource.Id.CloudSync);
            ButtonCreateSync.Text = "Login for Cloud";
            ButtonCreateSync.Click += ButtonCreateSyncCloud;
            codeText.Text = "Codes Unlocked!!" + codesneeded;
            ShareTodoJournal.Click += ShareTodoJournalClick;
            //Clicks
            hiddenbutton.Click += hiddenbuttonclick;
        }

        private void ShareTodoJournalClick(object sender, EventArgs eventArgs)
        {
            int i = 0;
            Int32.TryParse(editTextDateJournal.Text, out i);
            String txt = EmailReader.EmailFileRead.ReadFileFromDate(EmailFileRead.fileName1, i);
            Intent intentsend = new Intent();
            intentsend.SetAction(Intent.ActionSend);
            intentsend.PutExtra(Intent.ExtraText, txt);
            intentsend.SetType("text/plain");
            StartActivity(intentsend);
        }

        private void hiddenbuttonclick(object sender, EventArgs eventArgs)
        {
            var hidemybuttontext = FindViewById<Android.Widget.EditText>(Resource.Id.hiddenbuttontext);
            String pswd = hidemybuttontext.Text;
            if (EmailFileRead.CodeList.Contains(pswd.ToLower()) || pswd.ToLower() == "help" || pswd.ToLower() == "secret_code")
            {
                EmailFileRead.code = pswd.ToLower();
                SecretScreenClick(sender, eventArgs);
            }
            else
            {
                hidemybuttontext.Hint = "type 'help'";
            }
        }

        private void SecretScreenClick(object sender, EventArgs eventArgs)
        {
            SetContentView(Resource.Layout.activity_story);
            var shareStory = FindViewById<Android.Widget.ImageView>(Resource.Id.sharestory);
            shareStory.SetImageResource(Resource.Drawable.share);
            storytextView = FindViewById<Android.Widget.TextView>(Resource.Id.bookTextStoryScreen);
            storytextView.SetScrollContainer(true);
            storytextView.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            storytextView.ScrollTo(0, textViewLocation1);
            var storypic = FindViewById<Android.Widget.ImageView>(Resource.Id.storypic);
            if (EmailFileRead.code.ToLower() == "secret_code")
            {
                storytextView.SetText(Resource.Drawable.Halbook);
                var is1 = this.Resources.OpenRawResource(Resource.Drawable.Halbook);
                String text = EmailReader.EmailFileRead.ReadTextFile(is1);
                storytextView.Text = text;
                storypic.SetImageResource(Resource.Drawable.blueflowers);
            }
            else if (EmailFileRead.code.ToLower() == "help")
            {
                storytextView.SetText(Resource.Drawable.Reflections2);
                var is1 = this.Resources.OpenRawResource(Resource.Drawable.Reflections2);
                String text = EmailReader.EmailFileRead.ReadTextFile(is1);
                storytextView.Text = text;
                storypic.SetImageResource(Resource.Drawable.blueflowers);

            }
            if (EmailFileRead.code.ToLower() == EmailFileRead.CodeList[0])
            {
                storytextView.SetText(Resource.Drawable.Story1);
                var is1 = this.Resources.OpenRawResource(Resource.Drawable.Story1);
                String text = EmailReader.EmailFileRead.ReadTextFile(is1);
                storytextView.Text = text;
                storypic.SetImageResource(Resource.Drawable.chapter1);
            }
            else if (EmailFileRead.code.ToLower() == EmailFileRead.CodeList[1])
            {
                storytextView.SetText(Resource.Drawable.Story10);
                var is1 = this.Resources.OpenRawResource(Resource.Drawable.Story10);
                String text = EmailReader.EmailFileRead.ReadTextFile(is1);
                storytextView.Text = text;
                storypic.SetImageResource(Resource.Drawable.chapter2);
            }
            else if (EmailFileRead.code.ToLower() == EmailFileRead.CodeList[2])
            {
                storytextView.SetText(Resource.Drawable.Story50);
                var is1 = this.Resources.OpenRawResource(Resource.Drawable.Story25);
                String text = EmailReader.EmailFileRead.ReadTextFile(is1);
                storytextView.Text = text;
                storypic.SetImageResource(Resource.Drawable.chapter3);
            }
            else if (EmailFileRead.code.ToLower() == EmailFileRead.CodeList[3])
            {
                storytextView.SetText(Resource.Drawable.Story50);
                var is1 = this.Resources.OpenRawResource(Resource.Drawable.Story50);
                String text = EmailReader.EmailFileRead.ReadTextFile(is1);
                storytextView.Text = text;
                storypic.SetImageResource(Resource.Drawable.chapter4);
            }
            else if (EmailFileRead.code.ToLower() == EmailFileRead.CodeList[4] || EmailFileRead.code.ToLower() == EmailFileRead.CodeList[5]
                || EmailFileRead.code.ToLower() == EmailFileRead.CodeList[6])
            {
                storytextView.SetText(Resource.Drawable.WinText);
                var is1 = this.Resources.OpenRawResource(Resource.Drawable.WinText);
                String text = EmailReader.EmailFileRead.ReadTextFile(is1);
                storytextView.Text = text;
                storypic.SetImageResource(Resource.Drawable.chapter5);
            }
            else
            {
            }
            textViewLocation1 = storytextView.ScrollY;
            shareStory.Click += shareClick;
            var hiddenbutton1 = FindViewById<Android.Widget.Button>(Resource.Id.backstoryscreen);
            hiddenbutton1.Text = "Back";
            hiddenbutton1.Click += Button1ClickStory;
        }

        private void shareClick(object sender, EventArgs eventArgs)
        {
            String txt = storytextView.Text + "\nCreate Your Story";
            Intent intentsend = new Intent();
            intentsend.SetAction(Intent.ActionSend);
            intentsend.PutExtra(Intent.ExtraText, txt);
            intentsend.SetType("text/plain");
            StartActivity(intentsend);
        }

        //Create your story
        private void ButtonyourstoryscreenClick(object sender, EventArgs eventArgs)
        {
            //Initialize
            SetContentView(Resource.Layout.activity_user);
            textViewWrite = FindViewById<Android.Widget.TextView>(Resource.Id.yourbooktext);
            editTextWrite = FindViewById<Android.Widget.EditText>(Resource.Id.edityours);
            Buttonbackyourstory = FindViewById<Android.Widget.Button>(Resource.Id.back1);
            ButtonyourstoryscreenUpload = FindViewById<Android.Widget.Button>(Resource.Id.upload);
            ButtonDelete = FindViewById<Android.Widget.Button>(Resource.Id.freshstart);
            ButtonDelete1Line = FindViewById<Android.Widget.Button>(Resource.Id.delete1line);
            ButtonDateShare = FindViewById<Android.Widget.ImageView>(Resource.Id.buttonDateText);
            ButtonGoToEditPageStart = FindViewById<Android.Widget.Button>(Resource.Id.EditJournalPage);
            editTextDateShare = FindViewById<Android.Widget.TextView>(Resource.Id.editTextDateShare);
            ButtonDateShare.SetImageResource(Resource.Drawable.share);

            //var v = WindowManager.MaximumWindowMetrics.Bounds.Bottom;
            // if (v<1000)
            // {
            //    textViewWrite.SetHeight(300);
            // }
            Buttonbackyourstory.Text = "Back";
            ButtonyourstoryscreenUpload.Text = "Submit";
            //ButtonDateShare.Text = "Share Entry";
            ButtonGoToEditPageStart.Text = "Edit Full Journal";
            ButtonDelete.Text = "Reset";

            editTextWrite.SetScrollContainer(true);
            editTextWrite.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            editTextWrite.Hint = "Your entry here...";
            editTextWrite.SetHeight(300);
            ButtonDelete1Line.Text = "Delete previous line";

            textViewWrite.SetScrollContainer(true);
            textViewWrite.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            textViewWrite.Text = EmailFileRead.ReadText();

            //Clicks
            Buttonbackyourstory.Click += ButtonbackyourstoryscreenClick;
            ButtonyourstoryscreenUpload.Click += ButtonyourstoryscreenUploadClick;
            ButtonDelete.Click += ButtonDeleteClick;
            ButtonDelete1Line.Click += ButtonDeleteOneLineClick;
            ButtonDateShare.Click += ButtonClickDate;
            ButtonGoToEditPageStart.Click += ButtonGoToEditPage;
        }

        //Click date
        void ButtonClickDate(object sender, EventArgs eventArgs)
        {
            DateTime today = DateTime.Today;
            DatePickerDialog dialog = new DatePickerDialog(this, OnDateSet, today.Year, today.Month - 1, today.Day);
            dialog.DatePicker.MinDate = today.Millisecond;
            dialog.Show();
        }

        //Share
        void OnDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            editTextDateShare.Text = "Shared: " + e.Date.ToLongDateString();
            String txt2 = EmailReader.EmailFileRead.ReadFileFromDateToNextDay(e.Date);
            Intent intentsend = new Intent();
            intentsend.SetAction(Intent.ActionSend);
            intentsend.PutExtra(Intent.ExtraText, txt2);
            intentsend.SetType("text/plain");
            StartActivity(intentsend);
        }

        //Submit your story page button
        private void ButtonyourstoryscreenUploadClick(object sender, EventArgs eventArgs)
        {
            textViewWrite = FindViewById<Android.Widget.TextView>(Resource.Id.yourbooktext);
            editTextWrite = FindViewById<Android.Widget.EditText>(Resource.Id.edityours);
            if (EmailFileRead.FileSizeWarning())
            {
                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("Are you sure?");
                alert.SetMessage("Your file is too big, please share soon");
                alert.SetIcon(Resource.Drawable.alert);
                alert.SetButton("OK", (c, ev) =>
                {
                    //Does nothing
                });
                alert.SetButton2("CANCEL", (c, ev) => { });
                alert.Show();
            }
            else
            {

                String text = editTextWrite.Text;
                if (editTextWrite.Text == String.Empty)
                    text = "";
                EmailFileRead.WriteText(text);
                String totalText = EmailFileRead.ReadText();
                textViewWrite.Text = "";
                textViewWrite.Append(totalText);
                editTextWrite.Text = String.Empty;

                textViewWrite.SetScrollContainer(true);
                textViewWrite.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
                textViewWrite.Parent.RequestDisallowInterceptTouchEvent(false);
                //textViewWrite.ScrollTo(0, textViewWrite.Bottom - 200);
            }
        }

        //Delete - your story page
        private void ButtonDeleteClick(object sender, EventArgs eventArgs)
        {
            textViewWrite = FindViewById<Android.Widget.TextView>(Resource.Id.yourbooktext);
            editTextWrite = FindViewById<Android.Widget.EditText>(Resource.Id.edityours);
            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
            Android.App.AlertDialog alert = dialog.Create();
            alert.SetTitle("Are you sure?");
            alert.SetMessage("Deleting everything");
            alert.SetIcon(Resource.Drawable.alert);
            alert.SetButton("OK", (c, ev) =>
            {
                EmailFileRead.DeleteText();
                textViewWrite.Text = String.Empty;
            });
            alert.SetButton2("CANCEL", (c, ev) => { });
            alert.Show();
        }

        //Delete 1 line button - your story page
        private void ButtonDeleteOneLineClick(object sender, EventArgs eventArgs)
        {
            textViewWrite = FindViewById<Android.Widget.TextView>(Resource.Id.yourbooktext);
            editTextWrite = FindViewById<Android.Widget.EditText>(Resource.Id.edityours);

            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
            Android.App.AlertDialog alert = dialog.Create();
            alert.SetTitle("Are you sure?");
            alert.SetMessage("This will delete the previous line.");
            alert.SetIcon(Resource.Drawable.alert);
            alert.SetButton("OK", (c, ev) =>
            {
                EmailFileRead.DeleteLastLine();

                String totalText = EmailFileRead.ReadText();
                textViewWrite.Text = "";
                textViewWrite.Append(totalText);
            });
            alert.SetButton2("CANCEL", (c, ev) => { });
            alert.Show();
        }

        //Share button
        private void Button2Click(object sender, EventArgs eventArgs)
        {
            String txt2 = "\n Your story: \n" + EmailReader.EmailFileRead.ReadText();
            Intent intentsend = new Intent();
            intentsend.SetAction(Intent.ActionSend);
            intentsend.PutExtra(Intent.ExtraText, txt2);
            intentsend.SetType("text/plain");
            StartActivity(intentsend);
        }

        //Back button
        private void Button3Click(object sender, EventArgs eventArgs)
        {
            textViewLocation = textView.ScrollY;
            SetContentView(Resource.Layout.activity_main);

            //Image view
            togglePicture = 0;
            imageView = FindViewById<ImageView>(Resource.Id.NewImage);
            imageView.SetImageResource(Resource.Drawable.blueflowers);
            //imageView.Click += ImageOnClick;

            //Initialize
            Button2 = FindViewById<ImageView>(Resource.Id.Image);
            textView = FindViewById<Android.Widget.TextView>(Resource.Id.bookText);
            Button1 = FindViewById<Android.Widget.Button>(Resource.Id.EmailPageButton);
            Buttonyourstoryscreen = FindViewById<Android.Widget.Button>(Resource.Id.yourstoryscreenbutton);
            titleText = FindViewById<Android.Widget.ImageView>(Resource.Id.titleText);
            textView2 = FindViewById<Android.Widget.TextView>(Resource.Id.Instructions);
            ButtonTodoList = FindViewById<Android.Widget.Button>(Resource.Id.TodoListButton);
            Button2 = FindViewById<ImageView>(Resource.Id.Image);
            ImageCalendar = FindViewById<Android.Widget.Button>(Resource.Id.ImageCalendar);

            ImageCalendar.Text = "Change Image";
            var fileName2 = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "image.jpg");
            if (System.IO.File.Exists(fileName2))
            {
                Bitmap bitmap = BitmapFactory.DecodeFile(fileName2);
                imageView.SetImageBitmap(bitmap);
            }
            else
            {
                imageView.SetImageResource(Resource.Drawable.blueflowers);
            }
            //Properties
            textView2.Text = "Click mail to share your story!";
            Button1.Text = "Click to Read";

            if (toggletitle1 == 0)
            {
                titleText.SetImageResource(Resource.Drawable.MainTitlePic);
            }
            else
            {
                titleText.SetImageResource(Resource.Drawable.MainTitlePic1);
            }
            Buttonyourstoryscreen.Text = "Create your journal";

            ButtonTodoList.Text = "Create To Do List";

            //Clicks
            ImageCalendar.Click += ButtonImageCalendarClick;
            Button1.Click += Button1Click;
            Button2.Click += Button2Click;
            Buttonyourstoryscreen.Click += ButtonyourstoryscreenClick;
            ButtonTodoList.Click += ButtonTodoClick;
        }

        //Back button
        private void ButtonbackyourstoryscreenClick(object sender, EventArgs eventArgs)
        {
            SetContentView(Resource.Layout.activity_main);

            //Image view
            togglePicture = 0;
            imageView = FindViewById<ImageView>(Resource.Id.NewImage);
            imageView.SetImageResource(Resource.Drawable.blueflowers);
            //imageView.Click += ImageOnClick;

            //Initialize
            Button2 = FindViewById<ImageView>(Resource.Id.Image);
            textView = FindViewById<Android.Widget.TextView>(Resource.Id.bookText);
            Button1 = FindViewById<Android.Widget.Button>(Resource.Id.EmailPageButton);
            Buttonyourstoryscreen = FindViewById<Android.Widget.Button>(Resource.Id.yourstoryscreenbutton);
            titleText = FindViewById<Android.Widget.ImageView>(Resource.Id.titleText);
            textView2 = FindViewById<Android.Widget.TextView>(Resource.Id.Instructions);
            ButtonTodoList = FindViewById<Android.Widget.Button>(Resource.Id.TodoListButton);
            Button2 = FindViewById<ImageView>(Resource.Id.Image);
            ImageCalendar = FindViewById<Android.Widget.Button>(Resource.Id.ImageCalendar);

            ImageCalendar.Text = "Change Image";
            var fileName2 = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "image.jpg");
            if (System.IO.File.Exists(fileName2))
            {
                Bitmap bitmap = BitmapFactory.DecodeFile(fileName2);
                imageView.SetImageBitmap(bitmap);
            }
            else
            {
                imageView.SetImageResource(Resource.Drawable.blueflowers);
            }

            //Properties
            textView2.Text = "Click mail to share your story!";
            Button1.Text = "Click to Read";

            if (toggletitle1 == 0)
            {
                titleText.SetImageResource(Resource.Drawable.MainTitlePic);
            }
            else
            {
                titleText.SetImageResource(Resource.Drawable.MainTitlePic1);
            }
            Buttonyourstoryscreen.Text = "Create your journal";

            ButtonTodoList.Text = "Create To Do List";

            //Clicks
            ImageCalendar.Click += ButtonImageCalendarClick;
            Button1.Click += Button1Click;
            Button2.Click += Button2Click;
            Buttonyourstoryscreen.Click += ButtonyourstoryscreenClick;
            ButtonTodoList.Click += ButtonTodoClick;
        }

        //Rotate imageview
        private void ImageOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            var imageView = FindViewById<ImageView>(Resource.Id.NewImage);

            ImageCalendar.Text = "Change Image";
            var fileName2 = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "image.jpg");
            var fileName3 = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "imagesaved.jpg");
            if (System.IO.File.Exists(fileName2) && !System.IO.File.Exists(fileName3))
            {
                if (togglePicture == 0)
                {

                    Bitmap bitmap = BitmapFactory.DecodeFile(fileName2);
                    imageView.SetImageBitmap(bitmap);
                }
                else if (togglePicture == 1)
                {
                    imageView.SetImageResource(Resource.Drawable.pic8);
                }
                else
                {
                    imageView.SetImageResource(Resource.Drawable.blueflowers);

                }
                if (togglePicture >= 2)
                    togglePicture = 0;
                else
                    togglePicture++;
            }
            else if (System.IO.File.Exists(fileName2) && System.IO.File.Exists(fileName3))
            {
                if (togglePicture == 0)
                {

                    Bitmap bitmap = BitmapFactory.DecodeFile(fileName2);
                    imageView.SetImageBitmap(bitmap);
                }
                else if (togglePicture == 1)
                {
                    Bitmap bitmap = BitmapFactory.DecodeFile(fileName3);
                    imageView.SetImageBitmap(bitmap);
                }
                else if (togglePicture == 2)
                {
                    imageView.SetImageResource(Resource.Drawable.pinkflower);
                }
                else
                {
                    imageView.SetImageResource(Resource.Drawable.blueflowers);
                }
                if (togglePicture >= 3)
                    togglePicture = 0;
                else
                    togglePicture++;
            }
            else
            {
                if (togglePicture >= 1)
                    imageView.SetImageResource(Resource.Drawable.blueflowers);
                else
                    imageView.SetImageResource(Resource.Drawable.pinkflower);
                if (togglePicture >= 1)
                    togglePicture = 0;
                else
                    togglePicture++;
            }

        }

        //Android built in
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            // Check if the only required permission has been granted
            if ((grantResults.Length == 1) && (grantResults[0] == Permission.Granted))
            {
                Snackbar.Make(this.FindViewById(Resource.Layout.activity_image), 4, Snackbar.LengthShort).Show();
            }
            else
            {
            }

            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        //TODO LIST
        private void ButtonBackTodoListMainPage(object sender, EventArgs eventArgs)
        {
            SetContentView(Resource.Layout.activity_main);

            //Image view
            togglePicture = 0;
            imageView = FindViewById<ImageView>(Resource.Id.NewImage);
            imageView.SetImageResource(Resource.Drawable.blueflowers);
            //imageView.Click += ImageOnClick;

            //Initialize
            Button2 = FindViewById<ImageView>(Resource.Id.Image);
            textView = FindViewById<Android.Widget.TextView>(Resource.Id.bookText);
            Button1 = FindViewById<Android.Widget.Button>(Resource.Id.EmailPageButton);
            Buttonyourstoryscreen = FindViewById<Android.Widget.Button>(Resource.Id.yourstoryscreenbutton);
            titleText = FindViewById<Android.Widget.ImageView>(Resource.Id.titleText);
            textView2 = FindViewById<Android.Widget.TextView>(Resource.Id.Instructions);
            ButtonTodoList = FindViewById<Android.Widget.Button>(Resource.Id.TodoListButton);
            Button2 = FindViewById<ImageView>(Resource.Id.Image);
            ImageCalendar = FindViewById<Android.Widget.Button>(Resource.Id.ImageCalendar);

            ImageCalendar.Text = "Change Image";
            var fileName2 = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "image.jpg");
            if (System.IO.File.Exists(fileName2))
            {
                Bitmap bitmap = BitmapFactory.DecodeFile(fileName2);
                imageView.SetImageBitmap(bitmap);
            }
            else
            {
                imageView.SetImageResource(Resource.Drawable.blueflowers);
            }
            //Properties
            textView2.Text = "Click mail to share your story!";
            Button1.Text = "Click to Read";

            if (toggletitle1 == 0)
            {
                titleText.SetImageResource(Resource.Drawable.MainTitlePic);
            }
            else
            {
                titleText.SetImageResource(Resource.Drawable.MainTitlePic1);
            }
            Buttonyourstoryscreen.Text = "Create your journal";

            ButtonTodoList.Text = "Create To Do List";

            //Clicks
            ImageCalendar.Click += ButtonImageCalendarClick;
            Button1.Click += Button1Click;
            Button2.Click += Button2Click;
            Buttonyourstoryscreen.Click += ButtonyourstoryscreenClick;
            ButtonTodoList.Click += ButtonTodoClick;
        }

        private void ButtonTodoClick(object sender, EventArgs eventArgs)
        {
            SetContentView(Resource.Layout.activity_todo);
            textViewTodo = FindViewById<Android.Widget.TextView>(Resource.Id.todotext);
            editTextTodo = FindViewById<Android.Widget.EditText>(Resource.Id.todowrite);
            ButtonbackTodo = FindViewById<Android.Widget.Button>(Resource.Id.todoback);
            ButtonTodoUpload = FindViewById<Android.Widget.Button>(Resource.Id.todoupload);
            ButtonTodoDelete = FindViewById<Android.Widget.Button>(Resource.Id.todofreshstart);
            ButtonTodoDelete1Line = FindViewById<Android.Widget.Button>(Resource.Id.tododelete1line);
            ShareTodo = FindViewById<Android.Widget.ImageView>(Resource.Id.todoshare);
            editTextDate = FindViewById<Android.Widget.EditText>(Resource.Id.daysprior);
            editTextDate.Hint = "0 days";

            ButtonbackTodo.Text = "Back";
            ButtonTodoUpload.Text = "Submit";
            ButtonTodoDelete.Text = "Reset";
            //ButtonTodoDelete.Text = "Reset";

            editTextTodo.SetScrollContainer(true);
            editTextTodo.Parent.RequestDisallowInterceptTouchEvent(false);
            editTextTodo.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            editTextTodo.Hint = "Your entry here...";
            editTextTodo.SetHeight(300);
            ButtonTodoDelete1Line.Text = "Delete previous line";

            ButtonbackTodo.Click += ButtonBackTodoListMainPage;
            ButtonTodoUpload.Click += ButtonTodoUploadClick;
            ButtonTodoDelete.Click += ButtonTodoDeleteClick;
            ButtonTodoDelete1Line.Click += ButtonTodoDeleteOneLineClick;
            ShareTodo.SetImageResource(Resource.Drawable.share);

            //ShareTodo.Text = "Share Today";
            ShareTodo.Click += ShareTodoClick;

            textViewTodo.SetScrollContainer(true);
            textViewTodo.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            textViewTodo.Text = EmailFileRead.ReadText(EmailFileRead.fileName2);

        }

        private void ShareTodoClick(object sender, EventArgs eventArgs)
        {
            int i = 0;
            Int32.TryParse(editTextDate.Text, out i);
            String txt = EmailReader.EmailFileRead.ReadFileFromDate(EmailFileRead.fileName2, i);
            Intent intentsend = new Intent();
            intentsend.SetAction(Intent.ActionSend);
            intentsend.PutExtra(Intent.ExtraText, txt);
            intentsend.SetType("text/plain");
            StartActivity(intentsend);
        }

        private void ButtonTodoUploadClick(object sender, EventArgs eventArgs)
        {
            textViewWrite = FindViewById<Android.Widget.TextView>(Resource.Id.todotext);
            editTextTodo = FindViewById<Android.Widget.EditText>(Resource.Id.todowrite);
            if (EmailFileRead.FileSizeWarning(EmailFileRead.fileName2))
            {
                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("Are you sure?");
                alert.SetMessage("Your file is too big, please share soon");
                alert.SetIcon(Resource.Drawable.alert);
                alert.SetButton("OK", (c, ev) =>
                {
                    //Does nothing
                });
                alert.SetButton2("CANCEL", (c, ev) => { });
                alert.Show();
            }
            else
            {

                String text = editTextTodo.Text;
                if (editTextTodo.Text == String.Empty)
                    text = "";
                EmailFileRead.WriteText(text, EmailFileRead.fileName2, true);
                String totalText = EmailFileRead.ReadText(EmailFileRead.fileName2);
                textViewTodo.Text = "";
                textViewTodo.Append(totalText);
                editTextTodo.Text = String.Empty;

                textViewTodo.SetScrollContainer(true);
                textViewTodo.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
                textViewWrite.Parent.RequestDisallowInterceptTouchEvent(false);
                //textViewWrite.ScrollTo(0, textViewWrite.Bottom - 200);
            }
        }

        private void ButtonTodoDeleteClick(object sender, EventArgs eventArgs)
        {
            textViewWrite = FindViewById<Android.Widget.TextView>(Resource.Id.todotext);
            editTextTodo = FindViewById<Android.Widget.EditText>(Resource.Id.todowrite);
            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
            Android.App.AlertDialog alert = dialog.Create();
            alert.SetTitle("Are you sure?");
            alert.SetMessage("Deleting everything");
            alert.SetIcon(Resource.Drawable.alert);
            alert.SetButton("OK", (c, ev) =>
            {
                EmailFileRead.DeleteText(EmailFileRead.fileName2);
                textViewTodo.Text = String.Empty;
            });
            alert.SetButton2("CANCEL", (c, ev) => { });
            alert.Show();
        }

        private void ButtonTodoDeleteOneLineClick(object sender, EventArgs eventArgs)
        {
            textViewWrite = FindViewById<Android.Widget.TextView>(Resource.Id.todotext);
            editTextTodo = FindViewById<Android.Widget.EditText>(Resource.Id.todowrite);
            EmailFileRead.DeleteLastLine(EmailFileRead.fileName2);

            String totalText = EmailFileRead.ReadText(EmailFileRead.fileName2);
            textViewTodo.Text = "";
            textViewTodo.Append(totalText);
        }

        //Create your story
        private void ButtonBackEditPageClick(object sender, EventArgs eventArgs)
        {
            //Initialize
            SetContentView(Resource.Layout.activity_user);
            textViewWrite = FindViewById<Android.Widget.TextView>(Resource.Id.yourbooktext);
            editTextWrite = FindViewById<Android.Widget.EditText>(Resource.Id.edityours);
            Buttonbackyourstory = FindViewById<Android.Widget.Button>(Resource.Id.back1);
            ButtonyourstoryscreenUpload = FindViewById<Android.Widget.Button>(Resource.Id.upload);
            ButtonDelete = FindViewById<Android.Widget.Button>(Resource.Id.freshstart);
            ButtonDelete1Line = FindViewById<Android.Widget.Button>(Resource.Id.delete1line);
            ButtonDateShare = FindViewById<Android.Widget.ImageView>(Resource.Id.buttonDateText);
            ButtonGoToEditPageStart = FindViewById<Android.Widget.Button>(Resource.Id.EditJournalPage);

            //var v = WindowManager.MaximumWindowMetrics.Bounds.Bottom;
            // if (v<1000)
            // {
            //    textViewWrite.SetHeight(300);
            // }
            Buttonbackyourstory.Text = "Back";
            ButtonyourstoryscreenUpload.Text = "Submit";
            //ButtonDelete.Text = "Reset";
            //ButtonDateShare.Text = "Share Entry";
            ButtonGoToEditPageStart.Text = "Edit Full Journal";
            ButtonDelete.Text = "Reset";

            editTextWrite.SetScrollContainer(true);
            editTextWrite.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            editTextWrite.Hint = "Your entry here...";
            editTextWrite.SetHeight(300);
            ButtonDelete1Line.Text = "Delete previous line";
            ButtonDateShare.SetImageResource(Resource.Drawable.share);
            ButtonDelete.Text = "Reset";

            textViewWrite.SetScrollContainer(true);
            textViewWrite.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            textViewWrite.Text = EmailFileRead.ReadText();

            //Clicks
            Buttonbackyourstory.Click += ButtonbackyourstoryscreenClick;
            ButtonyourstoryscreenUpload.Click += ButtonyourstoryscreenUploadClick;
            ButtonDelete.Click += ButtonDeleteClick;
            ButtonDelete1Line.Click += ButtonDeleteOneLineClick;
            ButtonDateShare.Click += ButtonClickDate;
            ButtonGoToEditPageStart.Click += ButtonGoToEditPage;
        }

        //EditFull
        private void ButtonGoToEditPage(object sender, EventArgs eventArgs)
        {
            //Initialize
            SetContentView(Resource.Layout.activity_user_edit);
            ButtonSaveEditPage = FindViewById<Android.Widget.Button>(Resource.Id.SaveJournalEdit);
            ButtonBackEditPage = FindViewById<Android.Widget.Button>(Resource.Id.BackJournalEdit);
            EditJournal = FindViewById<Android.Widget.EditText>(Resource.Id.EditJournal);

            ButtonBackEditPage.Text = "Back";
            ButtonSaveEditPage.Text = "Save";

            EditJournal.SetScrollContainer(true);
            EditJournal.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            EditJournal.Text = (EmailFileRead.ReadText());

            //Clicks
            ButtonBackEditPage.Click += ButtonBackEditPageClick;
            ButtonSaveEditPage.Click += ButtonUploadFullEdit;
        }

        private void ButtonCreateSyncCloud(object sender, EventArgs eventArgs)
        {
            if (FireBaseRead.GetphoneID() != "")
            {
                SetContentView(Resource.Layout.activity_login_cloud);

                ButtonUploadBlobJournal = FindViewById<Android.Widget.Button>(Resource.Id.uploadblobjournal);
                ButtonDownloadBlobJournal = FindViewById<Android.Widget.Button>(Resource.Id.downloadblobjournal);
                ButtonDeleteBlobJournal = FindViewById<Android.Widget.Button>(Resource.Id.deleteblobjournal);
                ButtonUploadBlobTodo = FindViewById<Android.Widget.Button>(Resource.Id.uploadblobtodo);
                ButtonDownloadBlobTodo = FindViewById<Android.Widget.Button>(Resource.Id.downloadblobtodo);
                ButtonDeleteBlobTodo = FindViewById<Android.Widget.Button>(Resource.Id.deleteblobtodo);
                ViewBlob = FindViewById<Android.Widget.Button>(Resource.Id.viewBlob);
                textViewBlob = FindViewById<Android.Widget.TextView>(Resource.Id.OutputBlob);
                ButtonBackLoginPage = FindViewById<Android.Widget.Button>(Resource.Id.backLoginScreenCloud1);
                instructionsEmail = FindViewById<Android.Widget.TextView>(Resource.Id.logininstructionsCloud1);

                ButtonUploadBlobJournal.Text = "Upload Journal";
                ButtonDownloadBlobJournal.Text = "Download Journal";
                ButtonDeleteBlobJournal.Text = "Delete Journal";
                ButtonUploadBlobTodo.Text = "Upload Todo List";
                ButtonDownloadBlobTodo.Text = "Download Todo List";
                ButtonDeleteBlobTodo.Text = "Delete Todo List";
                ButtonBackLoginPage.Text = "Back";
                ViewBlob.Text = "View Blob Toggle";
                textViewBlob.Text = "";

                textViewBlob.SetScrollContainer(true);
                textViewBlob.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
                textViewBlob.Parent.RequestDisallowInterceptTouchEvent(false);
                textViewBlob.Text = "No connection";
                blobtoggle = 1;
                instructionsEmail.Text = "Welcome back! " + FireBaseRead.LoginEmail;

                ButtonUploadBlobJournal.Click += UploadToCloud1;
                ButtonDownloadBlobJournal.Click += DownloadCloud1;
                ButtonDeleteBlobJournal.Click += DeleteCloudClick1;
                ButtonUploadBlobTodo.Click += UploadToCloud2;
                ButtonDownloadBlobTodo.Click += DownloadCloud2;
                ButtonDeleteBlobTodo.Click += DeleteCloudClick2;
                ButtonBackLoginPage.Click += Button1Click;
                ViewBlob.Click += ViewBlobClick;

                if (FireBaseRead.IsConnected())
                {
                    ButtonUploadBlobJournal.Enabled = true;
                    ButtonDownloadBlobJournal.Enabled = true;
                    ButtonDeleteBlobJournal.Enabled = true;
                    ButtonUploadBlobTodo.Enabled = true;
                    ButtonDownloadBlobTodo.Enabled = true;
                    ButtonDeleteBlobTodo.Enabled = true;
                    ViewBlob.Enabled = true;
                    textViewBlob.Text = "Viewing Journal in Cloud: \n" + FireBaseRead.DownloadFileStream(EmailFileRead.fileName1);
                }
                else
                {
                    ButtonUploadBlobJournal.Enabled = false;
                    ButtonDownloadBlobJournal.Enabled = false;
                    ButtonDeleteBlobJournal.Enabled = false;
                    ButtonUploadBlobTodo.Enabled = false;
                    ButtonDownloadBlobTodo.Enabled = false;
                    ButtonDeleteBlobTodo.Enabled = false;
                    ViewBlob.Enabled = false;
                    instructionsEmail.Text = "Please turn on internet connection.";
                }

                int requestPermissions = 4000;
                string permiss = Android.Manifest.Permission.ReadExternalStorage;
                string permiss1 = Android.Manifest.Permission.WriteExternalStorage;
                string permiss2 = Android.Manifest.Permission.ManageExternalStorage;
                string permiss3 = Android.Manifest.Permission.Internet;
                if (!(ContextCompat.CheckSelfPermission(this, permiss) == (int)Permission.Granted) || !(ContextCompat.CheckSelfPermission(this, permiss2) == (int)Permission.Granted)
                        || !(ContextCompat.CheckSelfPermission(this, permiss1) == (int)Permission.Granted) || !(ContextCompat.CheckSelfPermission(this, permiss3) == (int)Permission.Granted))
                {
                    ActivityCompat.RequestPermissions(this, new String[] { permiss, permiss1, permiss2, permiss3 }, requestPermissions);
                }
            }
            else
            {
                SetContentView(Resource.Layout.activity_login);
                loginemail = FindViewById<Android.Widget.EditText>(Resource.Id.loginemailCloud);
                loginpassword = FindViewById<Android.Widget.EditText>(Resource.Id.loginpasswordCloud);
                submitbutton = FindViewById<Android.Widget.ImageView>(Resource.Id.submitButtonCloud);
                ButtonBackLoginPage = FindViewById<Android.Widget.Button>(Resource.Id.backLoginScreenCloud);
                instructionsEmail = FindViewById<Android.Widget.TextView>(Resource.Id.logininstructionsCloud);

                loginemail.Text = "";
                loginpassword.Text = "";
                ButtonBackLoginPage.Text = "Back";
                instructionsEmail.Text = "Please login, use an email and password, one time login! Cloud Services";

                if (FireBaseRead.IsConnected())
                {
                    submitbutton.Enabled = true;
                }
                else
                {
                    submitbutton.Enabled = false;
                    instructionsEmail.Text = "Please turn on internet connection.";
                }

                submitbutton.Click += LoginButtonClick;
                ButtonBackLoginPage.Click += Button1Click;

                int requestPermissions = 4000;
                string permiss = Android.Manifest.Permission.ReadExternalStorage;
                string permiss1 = Android.Manifest.Permission.WriteExternalStorage;
                string permiss2 = Android.Manifest.Permission.ManageExternalStorage;
                string permiss3 = Android.Manifest.Permission.Internet;
                if (!(ContextCompat.CheckSelfPermission(this, permiss) == (int)Permission.Granted) || !(ContextCompat.CheckSelfPermission(this, permiss2) == (int)Permission.Granted)
                        || !(ContextCompat.CheckSelfPermission(this, permiss1) == (int)Permission.Granted) || !(ContextCompat.CheckSelfPermission(this, permiss3) == (int)Permission.Granted))
                {
                    ActivityCompat.RequestPermissions(this, new String[] { permiss, permiss1, permiss2, permiss3 }, requestPermissions);
                }

            }

        }

        void LoginButtonClick(object sender, EventArgs eventArgs)
        {
            if (loginemail.Text != "" || loginpassword.Text != "")
            {
                if (FireBaseRead.GetphoneID() == "")
                {
                    FireBaseRead.cloudservices = true;
                    FireBaseRead.phoneID = loginemail.Text + loginpassword.Text;
                    FireBaseRead.Encrypt();
                    FireBaseRead.LoginEmail = loginemail.Text;
                    FireBaseRead.LoginPassword = loginpassword.Text;
                    SetContentView(Resource.Layout.activity_login_cloud);

                    ButtonUploadBlobJournal = FindViewById<Android.Widget.Button>(Resource.Id.uploadblobjournal);
                    ButtonDownloadBlobJournal = FindViewById<Android.Widget.Button>(Resource.Id.downloadblobjournal);
                    ButtonDeleteBlobJournal = FindViewById<Android.Widget.Button>(Resource.Id.deleteblobjournal);
                    ButtonUploadBlobTodo = FindViewById<Android.Widget.Button>(Resource.Id.uploadblobtodo);
                    ButtonDownloadBlobTodo = FindViewById<Android.Widget.Button>(Resource.Id.downloadblobtodo);
                    ButtonDeleteBlobTodo = FindViewById<Android.Widget.Button>(Resource.Id.deleteblobtodo);
                    ViewBlob = FindViewById<Android.Widget.Button>(Resource.Id.viewBlob);
                    textViewBlob = FindViewById<Android.Widget.TextView>(Resource.Id.OutputBlob);
                    ButtonBackLoginPage = FindViewById<Android.Widget.Button>(Resource.Id.backLoginScreenCloud1);
                    instructionsEmail = FindViewById<Android.Widget.TextView>(Resource.Id.logininstructionsCloud1);

                    ButtonUploadBlobJournal.Text = "Upload Journal";
                    ButtonDownloadBlobJournal.Text = "Download Journal";
                    ButtonDeleteBlobJournal.Text = "Delete Journal";
                    ButtonUploadBlobTodo.Text = "Upload Todo List";
                    ButtonDownloadBlobTodo.Text = "Download Todo List";
                    ButtonDeleteBlobTodo.Text = "Delete Todo List";
                    ButtonBackLoginPage.Text = "Back";
                    ViewBlob.Text = "View Blob Toggle";
                    textViewBlob.Text = "Viewing Journal in Cloud: \n" + FireBaseRead.DownloadFileStream(EmailFileRead.fileName1);
                    blobtoggle = 1;

                    textViewBlob.SetScrollContainer(true);
                    textViewBlob.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
                    textViewBlob.Parent.RequestDisallowInterceptTouchEvent(false);
                    instructionsEmail.Text = "Welcome " + FireBaseRead.LoginEmail;

                    if (FireBaseRead.IsConnected())
                    {
                        ButtonUploadBlobJournal.Enabled = true;
                        ButtonDownloadBlobJournal.Enabled = true;
                        ButtonDeleteBlobJournal.Enabled = true;
                        ButtonUploadBlobTodo.Enabled = true;
                        ButtonDownloadBlobTodo.Enabled = true;
                        ButtonDeleteBlobTodo.Enabled = true;
                        ViewBlob.Enabled = true;
                    }
                    else
                    {
                        ButtonUploadBlobJournal.Enabled = false;
                        ButtonDownloadBlobJournal.Enabled = false;
                        ButtonDeleteBlobJournal.Enabled = false;
                        ButtonUploadBlobTodo.Enabled = false;
                        ButtonDownloadBlobTodo.Enabled = false;
                        ButtonDeleteBlobTodo.Enabled = false;
                        ViewBlob.Enabled = false;
                    }

                    ButtonUploadBlobJournal.Click += UploadToCloud1;
                    ButtonDownloadBlobJournal.Click += DownloadCloud1;
                    ButtonDeleteBlobJournal.Click += DeleteCloudClick1;
                    ButtonUploadBlobTodo.Click += UploadToCloud2;
                    ButtonDownloadBlobTodo.Click += DownloadCloud2;
                    ButtonDeleteBlobTodo.Click += DeleteCloudClick2;
                    ButtonBackLoginPage.Click += Button1Click;
                    ViewBlob.Click += ViewBlobClick;

                    int requestPermissions = 4000;
                    string permiss = Android.Manifest.Permission.ReadExternalStorage;
                    string permiss1 = Android.Manifest.Permission.WriteExternalStorage;
                    string permiss2 = Android.Manifest.Permission.ManageExternalStorage;
                    string permiss3 = Android.Manifest.Permission.Internet;
                    if (!(ContextCompat.CheckSelfPermission(this, permiss) == (int)Permission.Granted) || !(ContextCompat.CheckSelfPermission(this, permiss2) == (int)Permission.Granted)
                            || !(ContextCompat.CheckSelfPermission(this, permiss1) == (int)Permission.Granted) || !(ContextCompat.CheckSelfPermission(this, permiss3) == (int)Permission.Granted))
                    {
                        ActivityCompat.RequestPermissions(this, new String[] { permiss, permiss1, permiss2, permiss3 }, requestPermissions);
                    }
                }
                else
                {
                    //Populate the fields
                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                    Android.App.AlertDialog alert = dialog.Create();
                    alert.SetTitle("Autofilling your most recent information");
                    alert.SetMessage("Adding your most recent information");
                    alert.SetIcon(Resource.Drawable.alert);
                    alert.SetButton("OK", (c, ev) =>
                    {
                        loginemail.Text = FireBaseRead.LoginEmail;
                        loginpassword.Text = FireBaseRead.LoginPassword;
                    });
                    alert.SetButton2("CANCEL", (c, ev) => { });
                    alert.Show();

                    if (FireBaseRead.IsConnected())
                    {
                        submitbutton.Enabled = true;
                    }
                    else
                    {
                        submitbutton.Enabled = false;
                        instructionsEmail.Text = "Please turn on internet connection.";
                    }
                }
            }
        }
        void ViewBlobClick(object sender, EventArgs eventArgs)
        {
            if (FireBaseRead.IsConnected())
            {
                if (blobtoggle == 0)
                {
                    textViewBlob.Text = "Viewing Journal in Cloud: \n" + FireBaseRead.DownloadFileStream(EmailFileRead.fileName1);
                    blobtoggle = 1;
                }
                else
                {
                    textViewBlob.Text = "Viewing Todo List in Cloud \n" + FireBaseRead.DownloadFileStream(EmailFileRead.fileName2);
                    blobtoggle = 0;
                }
            }
        }

        void UploadToCloud1(object sender, EventArgs eventArgs)
        {
            if (FireBaseRead.IsConnected())
            {
                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("Are you sure?");
                alert.SetMessage("This may take a while and will upload your journal to the cloud! Caution, this overwrites whatever is in the cloud.");
                alert.SetIcon(Resource.Drawable.alert);
                alert.SetButton("OK", (c, ev) =>
                {
                    FireBaseRead.UploadFile(EmailFileRead.fileName1);
                    textViewBlob.Text = "Uploaded journal: \n" + FireBaseRead.DownloadFileStream(EmailFileRead.fileName1);
                });
                alert.SetButton2("CANCEL", (c, ev) => { });
                alert.Show();
            }
        }

        void UploadToCloud2(object sender, EventArgs eventArgs)
        {
            if (FireBaseRead.IsConnected())
            {
                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("Are you sure?");
                alert.SetMessage("This may take a while and will upload your todo list to the cloud! Caution, this overwrites whatever is in the cloud.");
                alert.SetIcon(Resource.Drawable.alert);
                alert.SetButton("OK", (c, ev) =>
                {
                    FireBaseRead.UploadFile(EmailFileRead.fileName2);
                    textViewBlob.Text = "Uploaded Todo List: \n" + FireBaseRead.DownloadFileStream(EmailFileRead.fileName2);
                });
                alert.SetButton2("CANCEL", (c, ev) => { });
                alert.Show();
            }
        }

        void DeleteCloudClick1(object sender, EventArgs eventArgs)
        {
            if (FireBaseRead.IsConnected())
            {
                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("Are you sure?");
                alert.SetMessage("This may take a while and will delete your journal from the cloud!");
                alert.SetIcon(Resource.Drawable.alert);
                alert.SetButton("OK", (c, ev) =>
                {
                    FireBaseRead.DeleteFile(EmailFileRead.fileName1);
                    textViewBlob.Text = "Deleted Journal: \n" + FireBaseRead.DownloadFileStream(EmailFileRead.fileName1);

                });
                alert.SetButton2("CANCEL", (c, ev) => { });
                alert.Show();
            }
        }

        void DownloadCloud1(object sender, EventArgs eventArgs)
        {
            if (FireBaseRead.IsConnected())
            {
                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("Are you sure?");
                alert.SetMessage("This may take a while and will download your journal from the cloud! This will overwrite changes made on the device.");
                alert.SetIcon(Resource.Drawable.alert);
                alert.SetButton("OK", (c, ev) =>
                {
                    FireBaseRead.DownloadFile(EmailFileRead.fileName1);
                    textViewBlob.Text = "Downloaded Journal: \n" + FireBaseRead.DownloadFileStream(EmailFileRead.fileName1);
                });
                alert.SetButton2("CANCEL", (c, ev) => { });
                alert.Show();
            }
        }

        void DownloadCloud2(object sender, EventArgs eventArgs)
        {
            if (FireBaseRead.IsConnected())
            {
                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("Are you sure?");
                alert.SetMessage("This may take a while and will download your todo list from the cloud! This will overwrite changes made on the device.");
                alert.SetIcon(Resource.Drawable.alert);
                alert.SetButton("OK", (c, ev) =>
                {
                    FireBaseRead.DownloadFile(EmailFileRead.fileName2);
                    textViewBlob.Text = "Downloaded Todo List: \n" + FireBaseRead.DownloadFileStream(EmailFileRead.fileName2);
                });
                alert.SetButton2("CANCEL", (c, ev) => { });
                alert.Show();
            }
        }

        void DeleteCloudClick2(object sender, EventArgs eventArgs)
        {
            if (FireBaseRead.IsConnected())
            {
                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("Are you sure?");
                alert.SetMessage("This may take a while and will delete your file from the cloud!");
                alert.SetIcon(Resource.Drawable.alert);
                alert.SetButton("OK", (c, ev) =>
                {
                    FireBaseRead.DeleteFile(EmailFileRead.fileName2);
                    textViewBlob.Text = "Deleted Todo List: \n" + FireBaseRead.DownloadFileStream(EmailFileRead.fileName2);
                });
                alert.SetButton2("CANCEL", (c, ev) => { });
                alert.Show();
            }
        }

        //Submit your story page button
        private void ButtonUploadFullEdit(object sender, EventArgs eventArgs)
        {
            EditJournal = FindViewById<Android.Widget.EditText>(Resource.Id.EditJournal);
            if (EmailFileRead.FileSizeWarning())
            {
                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("Are you sure?");
                alert.SetMessage("Your file is too big, please share soon");
                alert.SetIcon(Resource.Drawable.alert);
                alert.SetButton("OK", (c, ev) =>
                {
                    //Does nothing
                });
                alert.SetButton2("CANCEL", (c, ev) => { });
                alert.Show();
            }
            else
            {
                String text = EditJournal.Text;
                if (EditJournal.Text == String.Empty)
                    text = "";
                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("Are you sure?");
                alert.SetMessage("This will edit your whole journal.");
                alert.SetIcon(Resource.Drawable.alert);
                alert.SetButton("OK", (c, ev) =>
                {
                    EmailFileRead.WriteAllText(text);
                    String totalText = EmailFileRead.ReadText();
                    EditJournal.Text = totalText;
                });
                alert.SetButton2("CANCEL", (c, ev) => { });
                alert.Show();
            }
        }

        //ImageScreen
        public void CheckPermission(String type = "camera")
        {
            if (type == "camera")
            {
                int requestPermissions = CameraImageId;
                string cameraPermission = Android.Manifest.Permission.Camera;

                if (!(ContextCompat.CheckSelfPermission(this, cameraPermission) == (int)Permission.Granted))
                {
                    ActivityCompat.RequestPermissions(this, new String[] { cameraPermission, }, requestPermissions);
                }
            }
            if (type == "pickimage")
            {
                int requestPermissions = PickImageId;
                string mediaPermission = Android.Manifest.Permission.AccessMediaLocation;

                if (!(ContextCompat.CheckSelfPermission(this, mediaPermission) == (int)Permission.Granted))
                {
                    ActivityCompat.RequestPermissions(this, new String[] { mediaPermission, }, requestPermissions);
                }
            }
        }

        public static readonly int PickImageId = 1002;
        public static readonly int PickImageId2 = 1000;
        public static readonly int CameraImageId = 1001;
        public static readonly int CameraImageId2 = 1003;

        // Create a Method OnActivityResult(it is select the image controller)
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                Android.Net.Uri uri = data.Data;
                imagechoosephoto.SetImageURI(uri);
                bmpDrawable();
                /*
                if (EmailFileRead.imageFileName != "")
                {
                    var v = readOCR(EmailFileRead.imageFileName);
                    if (v != "")
                        EmailFileRead.WriteText(v);
                }
                */
            }
            if ((requestCode == PickImageId2) && (resultCode == Result.Ok) && (data != null))
            {
                Android.Net.Uri uri = data.Data;
                imagechoosephoto.SetImageURI(uri);
                bmpDrawable("imagesaved.jpg");
                /*
                if (EmailFileRead.imageFileName != "")
                {
                    var v = readOCR(EmailFileRead.imageFileName);
                    if (v != "")
                        EmailFileRead.WriteText(v);
                }
                */
            }
            if ((requestCode == CameraImageId) && (resultCode == Result.Ok) && (data != null))
            {
                base.OnActivityResult(requestCode, resultCode, data);
                Bitmap bitmap = (Bitmap)data.Extras.Get("data");
                Matrix matrix = new Matrix();
                matrix.PostRotate(90);
                Bitmap rotated = Bitmap.CreateBitmap(bitmap, 0, 0, bitmap.Width, bitmap.Height,
                        matrix, true);
                imagechoosephoto.SetImageBitmap(rotated);
                bmpDrawable();
            }
            if ((requestCode == CameraImageId2) && (resultCode == Result.Ok) && (data != null))
            {
                base.OnActivityResult(requestCode, resultCode, data);
                Bitmap bitmap = (Bitmap)data.Extras.Get("data");
                Matrix matrix = new Matrix();
                matrix.PostRotate(90);
                Bitmap rotated = Bitmap.CreateBitmap(bitmap, 0, 0, bitmap.Width, bitmap.Height,
                        matrix, true);
                imagechoosephoto.SetImageBitmap(rotated);
                bmpDrawable("imagesaved");
            }

        }

        public int GetRotation(ExifInterface exif)
        {
            try
            {
                var orientation = (Android.Media.Orientation)exif.GetAttributeInt(ExifInterface.TagOrientation, (int)Android.Media.Orientation.Normal);

                switch (orientation)
                {
                    case Android.Media.Orientation.Rotate90:
                        return 90;
                    case Android.Media.Orientation.Rotate180:
                        return 180;
                    case Android.Media.Orientation.Rotate270:
                        return 270;
                    default:
                        return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public String bmpDrawable(String imageName = "image.jpg")
        {
            imagechoosephoto = FindViewById<ImageView>(Resource.Id.chooseimagephoto);
            Bitmap bmp = ((BitmapDrawable)imagechoosephoto.Drawable).Bitmap;
            if (bmp != null)
            {
                MemoryStream stream = new MemoryStream();
                bmp.Compress(Bitmap.CompressFormat.Png, 0, stream);
                byte[] reducedImage = stream.ToArray();
                var fileName2 = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), imageName);
                using (var fileOutputStream = new Java.IO.FileOutputStream(fileName2))
                {
                    fileOutputStream.Write(reducedImage);
                }
                /*
                if (bmp != null)
                {
                    bmp.Recycle();
                    bmp = null;
                }
                */
                return fileName2;
            }
            return "";
        }
        /*
        public String readOCR(String sourceFilePath)
        {
            try
            {
                var tessAPI = new TesseractApi(Android.App.Application.Context, AssetsDeployment.OncePerInitialization);
                tessAPI.Init("eng");
                tessAPI.SetImage(sourceFilePath);
                return tessAPI.Text;
            }
            catch (Exception e)
            { return ""; }
        }
        */

        private void ChooseMyPhoto(object sender, EventArgs eventArgs)
        {
            Intent = new Intent();
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), PickImageId);
        }

        private void ButtonImageCalendarClick(object sender, EventArgs eventArgs)
        {
            //Initialize
            SetContentView(Resource.Layout.activity_image);
            imagechoosephoto = FindViewById<ImageView>(Resource.Id.chooseimagephoto);
            ImagePageBack = FindViewById<Android.Widget.Button>(Resource.Id.BackImageScreen);
            ChoosePhoto = FindViewById<Android.Widget.ImageView>(Resource.Id.chooseimage);
            ChooseCameraPhoto = FindViewById<Android.Widget.ImageView>(Resource.Id.camerapicture);
            ButtonShareImagePage = FindViewById<Android.Widget.ImageView>(Resource.Id.imageDatePick);

            //ChoosePhoto.Text = "Choose Photo";
            ImagePageBack.Text = "Back";
            //ChooseCameraPhoto.Text = "Camera";
            //ButtonShareImagePage.Text = "Share";

            ChoosePhoto.SetImageResource(Resource.Drawable.gallery);
            ChooseCameraPhoto.SetImageResource(Resource.Drawable.camera);

            CheckPermission("camera");
            CheckPermission("pickimage");
            ButtonShareImagePage.SetImageResource(Resource.Drawable.share);

            var fileName2 = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "image.jpg");
            if (System.IO.File.Exists(fileName2))
            {
                Bitmap bitmap = BitmapFactory.DecodeFile(fileName2);
                imagechoosephoto.SetImageBitmap(bitmap);
            }
            else
            {
                imagechoosephoto.SetImageResource(Resource.Drawable.blueflowers);
            }

            var imagechoosephoto1 = FindViewById<ImageView>(Resource.Id.tinypic);
            imagechoosephoto1.SetImageResource(Resource.Drawable.pinkflower);

            titletoggle = FindViewById<ImageView>(Resource.Id.titletoggle);
            if (toggletitle1 == 0)
            {
                titletoggle.SetImageResource(Resource.Drawable.MainTitlePic);
            }
            else
            {
                titletoggle.SetImageResource(Resource.Drawable.MainTitlePic1);
            }

            //Clicks
            imagechoosephoto1.Click += ButtonImageSwitchClick1;
            titletoggle.Click += ButtonTitleToggleClick;
            ImagePageBack.Click += ButtonbackyourstoryscreenClick;
            ButtonShareImagePage.Click += ButtonClickDateImagePage;
            ChoosePhoto.Click += ChooseMyPhoto;
            ChooseCameraPhoto.Click += ButtonImageUploadClick;
        }
        public void ButtonTitleToggleClick(object sender, EventArgs eventArgs)
        {
            if (toggletitle1 == 0)
            {
                toggletitle1 = 1;
            }
            else
            {
                toggletitle1 = 0;
            }
            if (toggletitle1 == 0)
            {
                titletoggle.SetImageResource(Resource.Drawable.MainTitlePic);
            }
            else
            {
                titletoggle.SetImageResource(Resource.Drawable.MainTitlePic1);
            }


        }

        public void ButtonImageSwitchClick1(object sender, EventArgs eventArgs)
        {
            var fileName2 = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "image.jpg");
            if (System.IO.File.Exists(fileName2))
            {
                System.IO.File.Delete(fileName2);
                imagechoosephoto.SetImageResource(Resource.Drawable.blueflowers);
            }
            else
            {
                imagechoosephoto.SetImageResource(Resource.Drawable.blueflowers);
            }
        }

        //Change the photo upon toggle
        public void TogglePhotoCamera(object sender, EventArgs eventArgs)
        {
            var fileName2 = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "image.jpg");
            var fileName3 = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "imagesaved.jpg");
            if (System.IO.File.Exists(fileName2))
            {
                System.Threading.SpinWait.SpinUntil(() => BitmapFactory.DecodeFile(fileName2) != null, TimeSpan.FromSeconds(10));
                Bitmap bitmap = BitmapFactory.DecodeFile(fileName2);
                imagechoosephoto.SetImageBitmap(bitmap);
            }
            else
            {
                imagechoosephoto.SetImageResource(Resource.Drawable.pinkflower);
            }

        }



        //Click date
        void ButtonClickDateImagePage(object sender, EventArgs eventArgs)
        {
            DateTime today = DateTime.Today;
            DatePickerDialog dialog = new DatePickerDialog(this, OnDateSetImagePage, today.Year, today.Month - 1, today.Day);
            dialog.DatePicker.MinDate = today.Millisecond;
            dialog.Show();
        }

        //Share
        void OnDateSetImagePage(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            String txt2 = EmailReader.EmailFileRead.ReadFileFromDateToNextDay(e.Date);
            Intent intentsend = new Intent();
            intentsend.SetAction(Intent.ActionSendMultiple);
            intentsend.PutExtra(Intent.ExtraText, txt2);
            // var t = getImageUri(this);
            //if (t != null)
            //    intentsend.PutExtra(Intent.ExtraStream, t);
            intentsend.SetType("*/*");
            StartActivity(intentsend);
        }

        private Android.Net.Uri getImageUri(Context inContext)
        {
            //System.IO.Stream bytes = new System.IO.MemoryStream();
            //bmp.Compress(Bitmap.CompressFormat.Jpeg, 100, bytes);
            System.IO.Stream input = inContext.Assets.Open(EmailFileRead.imageFileName);
            Java.IO.FileOutputStream output = new Java.IO.FileOutputStream(EmailFileRead.publicImageFileName);
            byte[] buffer = new byte[1024];
            int size;
            while ((size = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, size);
            }
            input.Close();
            output.Close();
            Java.IO.File file = new Java.IO.File(EmailFileRead.publicImageFileName);
            Android.Net.Uri uri = Android.Net.Uri.FromFile(file);
            if (uri != null)
                return uri;
            else
                return null;
        }

        //Upload image
        private void ButtonImageUploadClick(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, CameraImageId);
        }


    }

}