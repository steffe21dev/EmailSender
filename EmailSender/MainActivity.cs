using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace EmailSender
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText subject,reciever,message;
        Button skicka;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            subject = FindViewById<EditText>(Resource.Id.ämne);
            reciever = FindViewById<EditText>(Resource.Id.mottagare);
            message = FindViewById<EditText>(Resource.Id.meddelande);
            skicka = FindViewById<Button>(Resource.Id.sendbutton);



            skicka.Click += Skicka_Click;

        }

        private void Skicka_Click(object sender, System.EventArgs e)
        {
            Intent email = new Intent(Intent.ActionSend);
            email.PutExtra(Intent.ExtraEmail, new string[] { reciever.Text.ToString() });
            email.PutExtra(Intent.ExtraSubject, subject.Text.ToString());
            email.PutExtra(Intent.ExtraText, message.Text.ToString());

            StartActivity(Intent.CreateChooser(email, "Skicka genom E-post"));

        }
    }
}