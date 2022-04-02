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

namespace HalBookAppAndroid
{
    [Activity(Label = "Create Your Story", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true, Icon="@drawable/ic_launcher_round", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        //Text views
        public Android.Widget.TextView textView;
        public Android.Widget.TextView textView2;
        public Android.Widget.EditText editTextWrite;
        public Android.Widget.TextView textViewWrite;
        public Android.Widget.TextView titleText;

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
        int togglePicture;
        int textViewLocation = 0;

	    //TODO view
        public Android.Widget.EditText editTextTodo;
        public Android.Widget.EditText editTextDate;
        public Android.Widget.TextView textViewTodo;
        public Android.Widget.Button ButtonTodoList;
        public Android.Widget.Button ButtonTodoUpload;
        public Android.Widget.Button ButtonTodoDelete;
        public Android.Widget.Button ButtonTodoDelete1Line;
        public Android.Widget.Button ButtonbackTodo;
        public Android.Widget.Button ShareTodo;
        public Android.Widget.Button ReadHiddenJournal;

        //Date 
        public Android.Widget.Button ButtonDateShare;
        public Android.Widget.TextView editTextDateShare;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            //Image view
            togglePicture = 0;
            imageView = FindViewById<ImageView>(Resource.Id.NewImage);
            imageView.SetImageResource(Resource.Drawable.pic5);
            imageView.Click += ImageOnClick;

            //Initialize
            Button2 = FindViewById<ImageView>(Resource.Id.Image);
            textView = FindViewById<Android.Widget.TextView>(Resource.Id.bookText);
            Button1 = FindViewById<Android.Widget.Button>(Resource.Id.EmailPageButton);
            Buttonyourstoryscreen = FindViewById<Android.Widget.Button>(Resource.Id.yourstoryscreenbutton);
            titleText = FindViewById<Android.Widget.TextView>(Resource.Id.titleText);
            textView2 = FindViewById<Android.Widget.TextView>(Resource.Id.Instructions);
            ButtonTodoList = FindViewById<Android.Widget.Button>(Resource.Id.TodoListButton);
            Button2 = FindViewById<ImageView>(Resource.Id.Image);

            //Properties
            textView2.Text = "Click mail to share your story!";
            Button1.Text = "Click to Read";

            titleText.Text = "Create Your Story!";
            Buttonyourstoryscreen.Text = "Create your journal"; 
  
            ButtonTodoList.Text = "Create To Do List";

            if (savedInstanceState != null)
                textViewLocation = savedInstanceState.GetInt("textViewLocation", 0);

            //Clicks
            Button1.Click += Button1Click;
            Button2.Click += Button2Click;
            Buttonyourstoryscreen.Click += ButtonyourstoryscreenClick;
            ButtonTodoList.Click += ButtonTodoClick;

        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("textViewLocation", textViewLocation);
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

            //Properties with
            Button3.Text = "Back";
            textView.SetScrollContainer(true);
            textView.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            textView.ScrollTo(0,textViewLocation);
            Button3.Click += Button3Click;
            String texty = EmailFileRead.ReadText();
            textView.Text = texty;
            textViewLocation = textView.ScrollY;
            hiddenbutton.Text = "Code";
            hidemybuttontext.Hint = "type 'hint'";

            //Clicks
            hiddenbutton.Click += hiddenbuttonclick;
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
                textView.SetText(Resource.Drawable.Halbook);
                var is1 = this.Resources.OpenRawResource(Resource.Drawable.Halbook);
                String text = EmailReader.EmailFileRead.ReadTextFile(is1);
                textView.Text = text;
                var hiddenbutton = FindViewById<Android.Widget.Button>(Resource.Id.hiddenbutton);
                hiddenbutton.Text = "Code";
                hiddenbutton.Click += hiddenbuttonclick;
            }
            else if(pswd.ToLower() == "hint")
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
                hidemybuttontext.Hint = "type 'hint'";
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
            ButtonDelete = FindViewById<Android.Widget.Button>(Resource.Id.freshstart);
            ButtonDelete1Line = FindViewById<Android.Widget.Button>(Resource.Id.delete1line);
            ButtonDateShare = FindViewById<Android.Widget.Button>(Resource.Id.buttonDateText);
            editTextDateShare = FindViewById<Android.Widget.TextView>(Resource.Id.editTextDateShare);

            Buttonbackyourstory.Text = "Back";
            ButtonyourstoryscreenUpload.Text = "Submit";
            ButtonDelete.Text = "Reset";
            ButtonDateShare.Text = "Share Entry";

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
            imageView.SetImageResource(Resource.Drawable.pic5);
            imageView.Click += ImageOnClick;

            //Initialize
            Button2 = FindViewById<ImageView>(Resource.Id.Image);
            textView = FindViewById<Android.Widget.TextView>(Resource.Id.bookText);
            Button1 = FindViewById<Android.Widget.Button>(Resource.Id.EmailPageButton);
            Buttonyourstoryscreen = FindViewById<Android.Widget.Button>(Resource.Id.yourstoryscreenbutton);
            titleText = FindViewById<Android.Widget.TextView>(Resource.Id.titleText);
            textView2 = FindViewById<Android.Widget.TextView>(Resource.Id.Instructions);
            ButtonTodoList = FindViewById<Android.Widget.Button>(Resource.Id.TodoListButton);
            Button2 = FindViewById<ImageView>(Resource.Id.Image);

            //Properties
            textView2.Text = "Click mail to share your story!";
            Button1.Text = "Click to Read";

            titleText.Text = "Create Your Story!";
            Buttonyourstoryscreen.Text = "Create your journal";

            ButtonTodoList.Text = "Create To Do List";

            //Clicks
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
            imageView.SetImageResource(Resource.Drawable.pic5);
            imageView.Click += ImageOnClick;

            //Initialize
            Button2 = FindViewById<ImageView>(Resource.Id.Image);
            textView = FindViewById<Android.Widget.TextView>(Resource.Id.bookText);
            Button1 = FindViewById<Android.Widget.Button>(Resource.Id.EmailPageButton);
            Buttonyourstoryscreen = FindViewById<Android.Widget.Button>(Resource.Id.yourstoryscreenbutton);
            titleText = FindViewById<Android.Widget.TextView>(Resource.Id.titleText);
            textView2 = FindViewById<Android.Widget.TextView>(Resource.Id.Instructions);
            ButtonTodoList = FindViewById<Android.Widget.Button>(Resource.Id.TodoListButton);
            Button2 = FindViewById<ImageView>(Resource.Id.Image);

            //Properties
            textView2.Text = "Click mail to share your story!";
            Button1.Text = "Click to Read";

            titleText.Text = "Create Your Story!";
            Buttonyourstoryscreen.Text = "Create your journal";

            ButtonTodoList.Text = "Create To Do List";

            //Clicks
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
            if (togglePicture >= 1)
                imageView.SetImageResource(Resource.Drawable.pic5);
            else
                imageView.SetImageResource(Resource.Drawable.pic8);
            if (togglePicture >= 1)
                togglePicture = 0;
            else
                togglePicture++;
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
                imageView.SetImageResource(Resource.Drawable.pic5);
                imageView.Click += ImageOnClick;

                //Initialize
                Button2 = FindViewById<ImageView>(Resource.Id.Image);
                textView = FindViewById<Android.Widget.TextView>(Resource.Id.bookText);
                Button1 = FindViewById<Android.Widget.Button>(Resource.Id.EmailPageButton);
                Buttonyourstoryscreen = FindViewById<Android.Widget.Button>(Resource.Id.yourstoryscreenbutton);
                titleText = FindViewById<Android.Widget.TextView>(Resource.Id.titleText);
                textView2 = FindViewById<Android.Widget.TextView>(Resource.Id.Instructions);
                ButtonTodoList = FindViewById<Android.Widget.Button>(Resource.Id.TodoListButton);
                Button2 = FindViewById<ImageView>(Resource.Id.Image);

                //Properties
                textView2.Text = "Click mail to share your story!";
                Button1.Text = "Click to Read";

                titleText.Text = "Create Your Story!";
                Buttonyourstoryscreen.Text = "Create your journal";

                ButtonTodoList.Text = "Create To Do List";

                //Clicks
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
                ButtonTodoDelete =  FindViewById<Android.Widget.Button>(Resource.Id.todofreshstart);
                ButtonTodoDelete1Line = FindViewById<Android.Widget.Button>(Resource.Id.tododelete1line);
                ShareTodo = FindViewById<Android.Widget.Button>(Resource.Id.todoshare);
                editTextDate = FindViewById<Android.Widget.EditText>(Resource.Id.daysprior);
                editTextDate.Hint = "0 days";

	            ButtonbackTodo.Text = "Back";
                ButtonTodoUpload.Text = "Submit";
                ButtonTodoDelete.SetBackgroundColor(Android.Graphics.Color.Red);
                ButtonTodoDelete.Text = "Reset";

                editTextTodo.SetScrollContainer(true);
                editTextTodo.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
                editTextTodo.Hint = "Your entry here...";
                editTextTodo.SetHeight(300);
                ButtonTodoDelete1Line.Text = "Delete previous line";

                ButtonbackTodo.Click += ButtonBackTodoListMainPage;
                ButtonTodoUpload.Click += ButtonTodoUploadClick;
                ButtonTodoDelete.Click += ButtonTodoDeleteClick;
                ButtonTodoDelete1Line.Click += ButtonTodoDeleteOneLineClick;
                ShareTodo.Text = "Share Today";
	            ShareTodo.Click += ShareTodoClick;

                textViewTodo.SetScrollContainer(true);
                textViewTodo.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
                textViewTodo.Text = EmailFileRead.ReadText(EmailFileRead.fileName2);

            }

            private void ShareTodoClick(object sender, EventArgs eventArgs)
            {
                int i = 0;
                Int32.TryParse(editTextDate.Text, out i);
                String txt = EmailReader.EmailFileRead.ReadFileFromDate(EmailFileRead.fileName2,i);
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
                    EmailFileRead.WriteText(text,EmailFileRead.fileName2,true);
                    String totalText = EmailFileRead.ReadText(EmailFileRead.fileName2);
                    textViewTodo.Text = "";
                    textViewTodo.Append(totalText);
                    editTextTodo.Text = String.Empty;

                    textViewTodo.SetScrollContainer(true);
                    textViewTodo.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
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
    }
}
