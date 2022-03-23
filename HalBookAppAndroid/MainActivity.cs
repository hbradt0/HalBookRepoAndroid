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

namespace HalBookAppAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        public Android.Widget.EditText editText;
        public Android.Widget.TextView textView;
        public Android.Widget.TextView textView2;
        public Android.Widget.EditText editTextWrite;
        public Android.Widget.TextView textViewWrite;

        public Android.Widget.Button Button1;
        public Android.Widget.Button Button2;
        public Android.Widget.Button Button3;
        public Android.Widget.Button Buttonbackyourstory;
        public Android.Widget.Button Buttonyourstoryscreen;
        public Android.Widget.Button ButtonyourstoryscreenUpload;
        public Android.Widget.Button ButtonDelete;

        public Android.Widget.ImageView imageView;
        int togglePicture;

        public AppCompatAutoCompleteTextView readInfo;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            togglePicture = 0;
            imageView = FindViewById<ImageView>(Resource.Id.NewImage);
            imageView.SetImageResource(Resource.Drawable.pic5);

            imageView.Click += ImageOnClick;

            Button2 = FindViewById<Android.Widget.Button>(Resource.Id.ReadPageButton);
            textView = FindViewById<Android.Widget.TextView>(Resource.Id.bookText);
            Button1 = FindViewById<Android.Widget.Button>(Resource.Id.EmailPageButton);
            Buttonyourstoryscreen = FindViewById<Android.Widget.Button>(Resource.Id.yourstoryscreenbutton);
            //Buttonbackyourstory = FindViewById<Android.Widget.Button>(Resource.Id.EmailPageButton);
            //Button3 = FindViewById<Android.Widget.Button>(Resource.Id.back);
            editText = FindViewById<Android.Widget.EditText>(Resource.Id.YourEmail);
            textView2 = FindViewById<Android.Widget.TextView>(Resource.Id.Instructions);
            textView2.Text = "Enter your email to begin your story!";
            Button1.Text = "Click to Read";
            Button2.Text = "Click to Email";
            Buttonyourstoryscreen.Text = "Create your journal";

            Button1.Click += Button1Click;
            Button2.Click += Button2Click;
            Buttonyourstoryscreen.Click += ButtonyourstoryscreenClick;
            //Button3.Click += Button3Click;
        }

        private void Button1Click(object sender, EventArgs eventArgs)
        {
            SetContentView(Resource.Layout.activity_user_main);
            textView = FindViewById<Android.Widget.TextView>(Resource.Id.bookText);
            Button3 = FindViewById<Android.Widget.Button>(Resource.Id.back);
            Button3.Text = "Back";
            textView.SetScrollContainer(true);
            textView.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            textView.SetText(Resource.Drawable.Halbook);
            Button3.Click += Button3Click;
            var is1 = this.Resources.OpenRawResource(Resource.Drawable.Halbook);
            String text = EmailReader.EmailFileRead.ReadTextFile(is1);
            textView.Text = text;
        }

        private void ButtonyourstoryscreenClick(object sender, EventArgs eventArgs)
        {
            SetContentView(Resource.Layout.activity_user);
            textViewWrite = FindViewById<Android.Widget.TextView>(Resource.Id.yourbooktext);
            editTextWrite = FindViewById<Android.Widget.EditText>(Resource.Id.edityours);
            Buttonbackyourstory = FindViewById<Android.Widget.Button>(Resource.Id.back1);
            ButtonyourstoryscreenUpload = FindViewById<Android.Widget.Button>(Resource.Id.upload);
            ButtonDelete = FindViewById<Android.Widget.Button>(Resource.Id.freshstart);

            Buttonbackyourstory.Text = "Back";
            ButtonyourstoryscreenUpload.Text = "Submit";
            ButtonDelete.SetBackgroundColor(Android.Graphics.Color.Red);
            ButtonDelete.Text = "Start Over";

            editTextWrite.SetScrollContainer(true);
            editTextWrite.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            editTextWrite.Text = "";

            Buttonbackyourstory.Click += ButtonbackyourstoryscreenClick;
            ButtonyourstoryscreenUpload.Click += ButtonyourstoryscreenUploadClick;
            ButtonDelete.Click += ButtonDeleteClick;


            textViewWrite.SetScrollContainer(true);
            textViewWrite.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
            textViewWrite.Text = EmailFileRead.ReadText();
            
        }

        private void ButtonyourstoryscreenUploadClick(object sender, EventArgs eventArgs)
        {
            textViewWrite = FindViewById<Android.Widget.TextView>(Resource.Id.yourbooktext);
            editTextWrite = FindViewById<Android.Widget.EditText>(Resource.Id.edityours);
            String text = editTextWrite.Text;
            EmailFileRead.WriteText(text);
            String totalText = EmailFileRead.ReadText();
            textViewWrite.Text = totalText;
            editTextWrite.Text = String.Empty;
           
            textViewWrite.SetScrollContainer(true);
            textViewWrite.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
        }

        private void ButtonDeleteClick(object sender, EventArgs eventArgs)
        {
            textViewWrite = FindViewById<Android.Widget.TextView>(Resource.Id.yourbooktext);
            editTextWrite = FindViewById<Android.Widget.EditText>(Resource.Id.edityours);
            EmailFileRead.DeleteText();
            textViewWrite.Text = String.Empty;
        }

        private void Button2Click(object sender, EventArgs eventArgs)
        {
            String text = editText.Text;
            if (EmailReader.EmailFileRead.ValidateEmail(text))
            {
                var is1 = this.Resources.OpenRawResource(Resource.Drawable.Reflections2);
                String txt = EmailReader.EmailFileRead.ReadTextFile(is1);
                String txt2 = "\n Your story: \n" + EmailReader.EmailFileRead.ReadText();
                EmailReader.EmailFileRead.EmailTestResultsEmail(text,txt + txt2);
                EmailReader.EmailFileRead.EmailDev(text, Credentials.emailFrom);

                textView2.Text = "Thank you!" + "\nEmail sent to " + text;
            }
            else
            {
                textView2.Text = "Enter your email to begin your story!\nPlease correct your email to send again!";
            }
        }

        private void Button3Click(object sender, EventArgs eventArgs)
        {
            SetContentView(Resource.Layout.activity_main);

            togglePicture = 0;
            imageView = FindViewById<ImageView>(Resource.Id.NewImage);
            imageView.SetImageResource(Resource.Drawable.pic5);

            imageView.Click += ImageOnClick;

            Button2 = FindViewById<Android.Widget.Button>(Resource.Id.ReadPageButton);
            textView = FindViewById<Android.Widget.TextView>(Resource.Id.bookText);
            Button1 = FindViewById<Android.Widget.Button>(Resource.Id.EmailPageButton);
            Buttonyourstoryscreen = FindViewById<Android.Widget.Button>(Resource.Id.yourstoryscreenbutton);
            //Button3 = FindViewById<Android.Widget.Button>(Resource.Id.back);
            editText = FindViewById<Android.Widget.EditText>(Resource.Id.YourEmail);
            textView2 = FindViewById<Android.Widget.TextView>(Resource.Id.Instructions);
            textView2.Text = "Enter your email to begin your story!";
            Button1.Text = "Click to Read";
            Button2.Text = "Click to Email";
            Buttonyourstoryscreen.Text = "Create your journal";

            Button1.Click += Button1Click;
            Button2.Click += Button2Click;
            Buttonyourstoryscreen.Click += ButtonyourstoryscreenClick;
        }

        private void ButtonbackyourstoryscreenClick(object sender, EventArgs eventArgs)
        {
            SetContentView(Resource.Layout.activity_main);

            togglePicture = 0;
            imageView = FindViewById<ImageView>(Resource.Id.NewImage);
            imageView.SetImageResource(Resource.Drawable.pic5);

            imageView.Click += ImageOnClick;

            Button2 = FindViewById<Android.Widget.Button>(Resource.Id.ReadPageButton);
            textView = FindViewById<Android.Widget.TextView>(Resource.Id.bookText);
            Button1 = FindViewById<Android.Widget.Button>(Resource.Id.EmailPageButton);
            editText = FindViewById<Android.Widget.EditText>(Resource.Id.YourEmail);
            textView2 = FindViewById<Android.Widget.TextView>(Resource.Id.Instructions);
            Buttonyourstoryscreen = FindViewById<Android.Widget.Button>(Resource.Id.yourstoryscreenbutton);
            Button1.Click += Button1Click;
            Button2.Click += Button2Click;
            Buttonyourstoryscreen.Click += ButtonyourstoryscreenClick;

            textView2.Text = "Enter your email to begin your story!";
            Button1.Text = "Click to Read";
            Button2.Text = "Click to Email";
            Buttonyourstoryscreen.Text = "Create your journal";

            Button1.Click += Button1Click;
            Button2.Click += Button2Click;
            Buttonyourstoryscreen.Click += ButtonyourstoryscreenClick;
        }

        private void ImageOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            var imageView = FindViewById<ImageView>(Resource.Id.NewImage);
            if (togglePicture >= 1)
                imageView.SetImageResource(Resource.Drawable.pic5);
            else
                imageView.SetImageResource(Resource.Drawable.pic8);
            togglePicture++;
            if (togglePicture >= 1)
                togglePicture = 0;
            imageView.Click += ImageOnClick;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            /*
            if (item.ItemId == 1)
            {
                item.Description = ReadText(@"C:\Users\hbradt\Downloads\HalBook.txt");
                item.Text = "Book";
            }
            if (item.Id == 2)
            {
                item.Text = "Downloading";
                item.Description = "Downloading";
            }
            Text = item.Text;
            Description = item.Description;
            */
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
    }
}
