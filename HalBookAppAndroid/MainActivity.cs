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
using Tesseract.Droid;
using Android.Graphics;
using Android.Graphics.Drawables;
using Java.IO;
using Android.Provider;
using Android.Media;
using Android.Util;
using AndroidX.Core.Content;
using AndroidX.Core.App;

namespace HalBookAppAndroid
{
    [Activity(Label = "Create Your Story", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true, Icon = "@drawable/ic_launcher_round", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        //Text views
        public Android.Widget.TextView textView;
        public Android.Widget.TextView textView2;
        public Android.Widget.EditText editTextWrite;
        public Android.Widget.TextView textViewWrite;
        public Android.Widget.ImageView titleText;

        //Buttons
        public Android.Widget.Button Button1;
        public Android.Widget.ImageView Button2;
        public Android.Widget.Button Button3;
        public Android.Widget.Button Buttonbackyourstory;
        public Android.Widget.Button Buttonyourstoryscreen;
        public Android.Widget.Button ButtonyourstoryscreenUpload;
        public Android.Widget.ImageView ButtonDelete;
        public Android.Widget.Button ButtonDelete1Line;
        public AppCompatAutoCompleteTextView readInfo;
        public Android.Widget.ImageView imageView;
        public Android.Widget.Button ImageCalendar;
        int togglePicture;
        int textViewLocation = 0;
        public Android.Widget.EditText editTextDateJournal;
        public Android.Widget.ImageView ShareTodoJournal;

        //TODO view
        public Android.Widget.EditText editTextTodo;
        public Android.Widget.EditText editTextDate;
        public Android.Widget.TextView textViewTodo;
        public Android.Widget.Button ButtonTodoList;
        public Android.Widget.Button ButtonTodoUpload;
        public Android.Widget.ImageView ButtonTodoDelete;
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
            outState.PutInt("toggletitle", toggletitle1);
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
            if (pswd == "secret_code")
            {
                textView = FindViewById<Android.Widget.TextView>(Resource.Id.bookText);
                textView.SetScrollContainer(true);
                textView.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
                textView.Parent.RequestDisallowInterceptTouchEvent(false);
                textView.SetText(Resource.Drawable.Halbook);
                var is1 = this.Resources.OpenRawResource(Resource.Drawable.Halbook);
                String text = EmailReader.EmailFileRead.ReadTextFile(is1);
                textView.Text = text;
                var hiddenbutton = FindViewById<Android.Widget.Button>(Resource.Id.hiddenbutton);
                hiddenbutton.Text = "Code";
                hiddenbutton.Click += hiddenbuttonclick;
            }
            else if (pswd.ToLower() == "help")
            {
                textView = FindViewById<Android.Widget.TextView>(Resource.Id.bookText);
                textView.SetScrollContainer(true);
                textView.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
                textView.SetText(Resource.Drawable.Halbook);
                var is1 = this.Resources.OpenRawResource(Resource.Drawable.Reflections2);
                String text = EmailReader.EmailFileRead.ReadTextFile(is1);
                textView.Text = text;
                var hiddenbutton = FindViewById<Android.Widget.Button>(Resource.Id.hiddenbutton);
                hiddenbutton.Text = "Code";
                hiddenbutton.Click += hiddenbuttonclick;
            }
            else
            {
                hidemybuttontext.Hint = "type 'help'";
            }
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
            ButtonDelete = FindViewById<Android.Widget.ImageView>(Resource.Id.freshstart);
            ButtonDelete1Line = FindViewById<Android.Widget.Button>(Resource.Id.delete1line);
            ButtonDateShare = FindViewById<Android.Widget.ImageView>(Resource.Id.buttonDateText);
            editTextDateShare = FindViewById<Android.Widget.TextView>(Resource.Id.editTextDateShare);
            ButtonGoToEditPageStart = FindViewById<Android.Widget.Button>(Resource.Id.EditJournalPage);

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

            editTextWrite.SetScrollContainer(true);
            editTextWrite.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            editTextWrite.Hint = "Your entry here...";
            editTextWrite.SetHeight(300);
            ButtonDelete1Line.Text = "Delete previous line";
            ButtonDelete.SetBackgroundColor(Android.Graphics.Color.Red);

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
                else if(togglePicture == 1)
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
                Snackbar.Make(this.FindViewById(Resource.Layout.activity_image),4,Snackbar.LengthShort).Show();
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
            ButtonTodoDelete = FindViewById<Android.Widget.ImageView>(Resource.Id.todofreshstart);
            ButtonTodoDelete1Line = FindViewById<Android.Widget.Button>(Resource.Id.tododelete1line);
            ShareTodo = FindViewById<Android.Widget.ImageView>(Resource.Id.todoshare);
            editTextDate = FindViewById<Android.Widget.EditText>(Resource.Id.daysprior);
            editTextDate.Hint = "0 days";

            ButtonbackTodo.Text = "Back";
            ButtonTodoUpload.Text = "Submit";
            ButtonTodoDelete.SetBackgroundColor(Android.Graphics.Color.Red);
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
            ButtonDelete = FindViewById<Android.Widget.ImageView>(Resource.Id.freshstart);
            ButtonDelete1Line = FindViewById<Android.Widget.Button>(Resource.Id.delete1line);
            ButtonDateShare = FindViewById<Android.Widget.ImageView>(Resource.Id.buttonDateText);
            editTextDateShare = FindViewById<Android.Widget.TextView>(Resource.Id.editTextDateShare);
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

            editTextWrite.SetScrollContainer(true);
            editTextWrite.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            editTextWrite.Hint = "Your entry here...";
            editTextWrite.SetHeight(300);
            ButtonDelete1Line.Text = "Delete previous line";
            ButtonDateShare.SetImageResource(Resource.Drawable.share);

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
            if(type == "pickimage")
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
                System.Threading.SpinWait.SpinUntil(() => BitmapFactory.DecodeFile(fileName2)!=null, TimeSpan.FromSeconds(10));
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
