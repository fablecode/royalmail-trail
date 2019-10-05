using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace royalmail.trail.Views.Main
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ReferenceNumberEntry.Focus();

            base.OnAppearing();
        }
    }


    public class Rootobject
    {
        public Mailpieces mailPieces { get; set; }
    }

    public class Mailpieces
    {
        public string mailPieceId { get; set; }
        public string carrierShortName { get; set; }
        public string carrierFullName { get; set; }
        public Summary summary { get; set; }
        public Event[] events { get; set; }
        public Links links { get; set; }
    }

    public class Summary
    {
        public string uniqueItemId { get; set; }
        public string oneDBarcode { get; set; }
        public string productId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public string productCategory { get; set; }
        public string destinationCountryCode { get; set; }
        public string destinationCountryName { get; set; }
        public string originCountryCode { get; set; }
        public string originCountryName { get; set; }
        public string lastEventCode { get; set; }
        public string lastEventName { get; set; }
        public DateTime lastEventDateTime { get; set; }
        public string lastEventLocationName { get; set; }
        public string statusDescription { get; set; }
        public string statusCategory { get; set; }
        public string statusHelpText { get; set; }
        public string summaryLine { get; set; }
    }

    public class Links
    {
        public LinkSummary summary { get; set; }
    }

    public class LinkSummary
    {
        public string href { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class Event
    {
        public string eventCode { get; set; }
        public string eventName { get; set; }
        public DateTime eventDateTime { get; set; }
        public string locationName { get; set; }
    }

}
