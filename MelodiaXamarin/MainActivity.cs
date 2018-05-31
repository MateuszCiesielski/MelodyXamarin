using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;
using System;

namespace MelodiaXamarin
{
    [Activity(Label = "MelodiaXamarin", MainLauncher = true)]
    public class MainActivity : Activity
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        Model model = null;
        MediaPlayer player = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            timer.Interval = 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            FindViewById<Button>(Resource.Id.startButton).Click += Start_Click;
            FindViewById<Button>(Resource.Id.wyjdzButton).Click += KoniecButton_Click;
        }

        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (model != null)
            {
                model.Czas -= 1;
                if (model.Czas <= 0)
                {
                    timer.Stop();
                    koniec(true); // jeśli czas się skończy - komunikat końcowy
                }
            }
        }

        private void przygotujZawartość()
        {
            if (model != null)
            {
                FindViewById<Button>(Resource.Id.odp1Button).Text = Baza.Tytuł[model.WartościPrzycisków[0]];
                FindViewById<Button>(Resource.Id.odp2Button).Text = Baza.Tytuł[model.WartościPrzycisków[1]];
                FindViewById<Button>(Resource.Id.odp3Button).Text = Baza.Tytuł[model.WartościPrzycisków[2]];
                FindViewById<Button>(Resource.Id.odp4Button).Text = Baza.Tytuł[model.WartościPrzycisków[3]];
                FindViewById<TextView>(Resource.Id.czasWartoscText).Text = model.Czas.ToString();
                FindViewById<TextView>(Resource.Id.wynikWartoscText).Text = model.Wynik.ToString();
                FindViewById<TextView>(Resource.Id.utworWartoscText).Text = model.NrUtworu.ToString();
                
                player = MediaPlayer.Create(this, Baza.Identyfikator[model.Odpowiedź]);
                player.Start();
            }
        }

        // -------- MENU ----------

        private void Start_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Poziom);
            FindViewById<Button>(Resource.Id.latwyButton).Click += Latwy_Click;
            FindViewById<Button>(Resource.Id.sredniButton).Click += Sredni_Click;
            FindViewById<Button>(Resource.Id.trudnyButton).Click += Trudny_Click;
            FindViewById<Button>(Resource.Id.doMenuButton).Click += KoniecButton_Click;
        }

        private void Wyjdź_Click(object sender, EventArgs e)
        {
            Finish();
        }

        // --------POZIOM ---------

        private void Latwy_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Gra);
            FindViewById<Button>(Resource.Id.odp1Button).Click += Odp1_Click;
            FindViewById<Button>(Resource.Id.odp2Button).Click += Odp2_Click;
            FindViewById<Button>(Resource.Id.odp3Button).Click += Odp3_Click;
            FindViewById<Button>(Resource.Id.odp4Button).Click += Odp4_Click;

            model = new Model(); // --- utworzenie instancji modelu, aktywowanie konstruktorów ---

            model.Czas = 25;

            przygotujZawartość(); // --- naniesienie na przyciski zawartości ---
            timer.Start(); // --- wystartowanie zegara ---
        }

        private void Sredni_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Gra);
            FindViewById<Button>(Resource.Id.odp1Button).Click += Odp1_Click;
            FindViewById<Button>(Resource.Id.odp2Button).Click += Odp2_Click;
            FindViewById<Button>(Resource.Id.odp3Button).Click += Odp3_Click;
            FindViewById<Button>(Resource.Id.odp4Button).Click += Odp4_Click;

            model = new Model(); // --- utworzenie instancji modelu, aktywowanie konstruktorów ---

            model.Czas = 20;

            przygotujZawartość(); // --- naniesienie na przyciski zawartości ---
            timer.Start(); // --- wystartowanie zegara ---
        }

        private void Trudny_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Gra);
            FindViewById<Button>(Resource.Id.odp1Button).Click += Odp1_Click;
            FindViewById<Button>(Resource.Id.odp2Button).Click += Odp2_Click;
            FindViewById<Button>(Resource.Id.odp3Button).Click += Odp3_Click;
            FindViewById<Button>(Resource.Id.odp4Button).Click += Odp4_Click;

            model = new Model(); // --- utworzenie instancji modelu, aktywowanie konstruktorów ---

            model.Czas = 15;

            przygotujZawartość(); // --- naniesienie na przyciski zawartości ---
            timer.Start(); // --- wystartowanie zegara ---
        }

        // -------- GRA -----------

        private void Odp1_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Komunikat); // --- pojawienie się komunikatu ---
            FindViewById<Button>(Resource.Id.komunikatButton).Click += KomunikatButton_Click;
            player.Stop();
            timer.Stop();
            
            if (model.OdpID == 0) // --- została wybrana prawidłowa odpowiedź
            {
                FindViewById<TextView>(Resource.Id.komunikatDobrzeText).Visibility = Android.Views.ViewStates.Visible;
                model.Wynik += 1;
            }
            else // --- zła odpowiedź
            {
                FindViewById<TextView>(Resource.Id.komunikatZleText).Visibility = Android.Views.ViewStates.Visible;
            }
        }

        private void Odp2_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Komunikat); // --- pojawienie się komunikatu ---
            FindViewById<Button>(Resource.Id.komunikatButton).Click += KomunikatButton_Click;
            player.Stop();
            timer.Stop();

            if (model.OdpID == 1) // --- została wybrana prawidłowa odpowiedź
            {
                FindViewById<TextView>(Resource.Id.komunikatDobrzeText).Visibility = Android.Views.ViewStates.Visible;
                model.Wynik += 1;
            }
            else // --- zła odpowiedź
            {
                FindViewById<TextView>(Resource.Id.komunikatZleText).Visibility = Android.Views.ViewStates.Visible;
            }
        }

        private void Odp3_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Komunikat); // --- pojawienie się komunikatu ---
            FindViewById<Button>(Resource.Id.komunikatButton).Click += KomunikatButton_Click;
            player.Stop();
            timer.Stop();

            if (model.OdpID == 2) // --- została wybrana prawidłowa odpowiedź
            {
                FindViewById<TextView>(Resource.Id.komunikatDobrzeText).Visibility = Android.Views.ViewStates.Visible;
                model.Wynik += 1;
            }
            else // --- zła odpowiedź
            {
                FindViewById<TextView>(Resource.Id.komunikatZleText).Visibility = Android.Views.ViewStates.Visible;
            }
        }

        private void Odp4_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Komunikat); // --- pojawienie się komunikatu ---
            FindViewById<Button>(Resource.Id.komunikatButton).Click += KomunikatButton_Click;
            player.Stop();
            timer.Stop();

            if (model.OdpID == 3) // --- została wybrana prawidłowa odpowiedź
            {
                FindViewById<TextView>(Resource.Id.komunikatDobrzeText).Visibility = Android.Views.ViewStates.Visible;
                model.Wynik += 1;
            }
            else // --- zła odpowiedź
            {
                FindViewById<TextView>(Resource.Id.komunikatZleText).Visibility = Android.Views.ViewStates.Visible;
            }
        }

        private void KomunikatButton_Click(object sender, EventArgs e)
        {
            FindViewById<TextView>(Resource.Id.komunikatDobrzeText).Visibility = Android.Views.ViewStates.Invisible;
            FindViewById<TextView>(Resource.Id.komunikatZleText).Visibility = Android.Views.ViewStates.Invisible;
            SetContentView(Resource.Layout.Gra);
            FindViewById<Button>(Resource.Id.odp1Button).Click += Odp1_Click;
            FindViewById<Button>(Resource.Id.odp2Button).Click += Odp2_Click;
            FindViewById<Button>(Resource.Id.odp3Button).Click += Odp3_Click;
            FindViewById<Button>(Resource.Id.odp4Button).Click += Odp4_Click;

            model.NrUtworu++;
            if (model.NrUtworu >= 10) // --- został osiągnięty limit pytań (10) - koniec gry - komunikat
            {
                koniec(false);
            }
            else // --- nowe pytanie, wylosowanie odpowiedzi
            {
                model.Losuj();
                przygotujZawartość();
                timer.Start();
            }
        }

        private void KoniecButton_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Main);
            FindViewById<Button>(Resource.Id.startButton).Click += Start_Click;
            FindViewById<Button>(Resource.Id.wyjdzButton).Click += KoniecButton_Click;
        }

        private void koniec(bool czyCzas)
        {
            timer.Stop();
            player.Stop();
            SetContentView(Resource.Layout.Koniec);
            FindViewById<Button>(Resource.Id.koniecButton).Click += KoniecButton_Click;
            FindViewById<TextView>(Resource.Id.wynikKoniecWartoscText).Text = model.Wynik.ToString();
            if (czyCzas) FindViewById<TextView>(Resource.Id.koniecText).Text = " KONIEC CZASU";
            else
            {
                FindViewById<TextView>(Resource.Id.koniecPozostalyCzasText).Text = "POZOSTAŁY CZAS: " + model.Czas;
                FindViewById<TextView>(Resource.Id.koniecText).Text = "       KONIEC";
            }
        }
    }
}