using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WPDirect
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        Android.Support.Design.Widget.TextInputEditText editNumber;
        Button btnSend;
        Button btnClear;
        EditText editMessage;
        List<countryItems> ctList;
        Spinner spCt;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            loadList();
            editNumber = FindViewById<Android.Support.Design.Widget.TextInputEditText>(Resource.Id.editNumber);
            editMessage = FindViewById<EditText>(Resource.Id.editMessage);
            btnSend = FindViewById<Button>(Resource.Id.btnSend);
            btnClear = FindViewById<Button>(Resource.Id.btnClear);
            spCt = FindViewById<Spinner>(Resource.Id.spinCountryList);
            spCt.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(SpCt_ItemSelected);
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, getList());
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spCt.Adapter = adapter;

            btnSend.Click += BtnSend_Click;
            btnClear.Click += BtnClear_Click;
            spCt.SetSelection(ctList.FindIndex(item => item.ctName == getLang()));
            editMessage.Hint = GetString(Resource.String.messageHint);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            int index = ctList.FindIndex(item => item.ctName == spCt.SelectedItem.ToString());
            editNumber.Text = ctList[index].ctCode;
            editMessage.Text = "";

        }

        private void SpCt_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            int index = ctList.FindIndex(item => item.ctName == spCt.SelectedItem.ToString());
            editNumber.Text = ctList[index].ctCode;
        }

        private void BtnSend_Click(object sender, System.EventArgs e)
        {
            sendMSG(editNumber.Text, editMessage.Text);
        }

        void sendMSG(string phoneNumber, string message)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("whatsapp://send/?text=");
                sb.Append(message);
                sb.Append("&phone=");
                sb.Append(phoneNumber);
                var intent = new Intent("android.intent.action.VIEW", Android.Net.Uri.Parse(sb.ToString()));
                StartActivity(intent);
            }
            catch (ActivityNotFoundException){
                Toast.MakeText(this, Resource.String.notFoundActivity, ToastLength.Long).Show();
            }
        }

        string getLang()
        {
            return Locale.GetDefault(Locale.Category.Display).ISO3Country + "/" + Locale.GetDefault(Locale.Category.Display).Country;
        }

        string getAppLang()
        {
            string lng="";
            if (btnClear.Text == "Temizle")
                lng = "TR";
            else if (btnClear.Text == "Clear")
                lng = "EN";
            return lng;
        }


        void loadList()
        {
            ctList = new List<countryItems>{
                new countryItems { ctName = "ALB/AL", ctCode="355" },
                new countryItems { ctName = "AFG/AF", ctCode="93" },
                new countryItems { ctName = "DZA/DZ", ctCode="213" },
                new countryItems { ctName = "ASM/AS", ctCode="1-684" },
                new countryItems { ctName = "AND/AD", ctCode="376" },
                new countryItems { ctName = "AGO/AO", ctCode="244" },
                new countryItems { ctName = "AIA/AI", ctCode="1-264" },
                new countryItems { ctName = "ATA/AQ", ctCode="672" },
                new countryItems { ctName = "ATG/AG", ctCode="1-268" },
                new countryItems { ctName = "ARG/AR", ctCode="54" },
                new countryItems { ctName = "ARM/AM", ctCode="374" },
                new countryItems { ctName = "ABW/AW", ctCode="297" },
                new countryItems { ctName = "AUS/AU", ctCode="61" },
                new countryItems { ctName = "AUT/AT", ctCode="43" },
                new countryItems { ctName = "AZE/AZ", ctCode="994" },
                new countryItems { ctName = "BHS/BS", ctCode="1-242" },
                new countryItems { ctName = "BHR/BH", ctCode="973" },
                new countryItems { ctName = "BGD/BD", ctCode="880" },
                new countryItems { ctName = "BRB/BB", ctCode="1-246" },
                new countryItems { ctName = "BLR/BY", ctCode="375" },
                new countryItems { ctName = "BEL/BE", ctCode="32" },
                new countryItems { ctName = "BLZ/BZ", ctCode="501" },
                new countryItems { ctName = "BEN/BJ", ctCode="229" },
                new countryItems { ctName = "BMU/BM", ctCode="1-441" },
                new countryItems { ctName = "BTN/BT", ctCode="975" },
                new countryItems { ctName = "BOL/BO", ctCode="591" },
                new countryItems { ctName = "BIH/BA", ctCode="387" },
                new countryItems { ctName = "BWA/BW", ctCode="267" },
                new countryItems { ctName = "BRA/BR", ctCode="55" },
                new countryItems { ctName = "IOT/IO", ctCode="246" },
                new countryItems { ctName = "VGB/VG", ctCode="1-284" },
                new countryItems { ctName = "BRN/BN", ctCode="673" },
                new countryItems { ctName = "BGR/BG", ctCode="359" },
                new countryItems { ctName = "BFA/BF", ctCode="226" },
                new countryItems { ctName = "BDI/BI", ctCode="257" },
                new countryItems { ctName = "KHM/KH", ctCode="855" },
                new countryItems { ctName = "CMR/CM", ctCode="237" },
                new countryItems { ctName = "CAN/CA", ctCode="1" },
                new countryItems { ctName = "CPV/CV", ctCode="238" },
                new countryItems { ctName = "CYM/KY", ctCode="1-345" },
                new countryItems { ctName = "CAF/CF", ctCode="236" },
                new countryItems { ctName = "TCD/TD", ctCode="235" },
                new countryItems { ctName = "CHL/CL", ctCode="56" },
                new countryItems { ctName = "CHN/CN", ctCode="86" },
                new countryItems { ctName = "CXR/CX", ctCode="61" },
                new countryItems { ctName = "CCK/CC", ctCode="61" },
                new countryItems { ctName = "COL/CO", ctCode="57" },
                new countryItems { ctName = "COM/KM", ctCode="269" },
                new countryItems { ctName = "COK/CK", ctCode="682" },
                new countryItems { ctName = "CRI/CR", ctCode="506" },
                new countryItems { ctName = "HRV/HR", ctCode="385" },
                new countryItems { ctName = "CUB/CU", ctCode="53" },
                new countryItems { ctName = "CUW/CW", ctCode="599" },
                new countryItems { ctName = "CYP/CY", ctCode="357" },
                new countryItems { ctName = "CZE/CZ", ctCode="420" },
                new countryItems { ctName = "COD/CD", ctCode="243" },
                new countryItems { ctName = "DNK/DK", ctCode="45" },
                new countryItems { ctName = "DJI/DJ", ctCode="253" },
                new countryItems { ctName = "DMA/DM", ctCode="1-767" },
                new countryItems { ctName = "DOM/DO", ctCode="1-809,1-829,1-849" },
                new countryItems { ctName = "TLS/TL", ctCode="670" },
                new countryItems { ctName = "ECU/EC", ctCode="593" },
                new countryItems { ctName = "EGY/EG", ctCode="20" },
                new countryItems { ctName = "SLV/SV", ctCode="503" },
                new countryItems { ctName = "GNQ/GQ", ctCode="240" },
                new countryItems { ctName = "ERI/ER", ctCode="291" },
                new countryItems { ctName = "EST/EE", ctCode="372" },
                new countryItems { ctName = "ETH/ET", ctCode="251" },
                new countryItems { ctName = "FLK/FK", ctCode="500" },
                new countryItems { ctName = "FRO/FO", ctCode="298" },
                new countryItems { ctName = "FJI/FJ", ctCode="679" },
                new countryItems { ctName = "FIN/FI", ctCode="358" },
                new countryItems { ctName = "FRA/FR", ctCode="33" },
                new countryItems { ctName = "PYF/PF", ctCode="689" },
                new countryItems { ctName = "GAB/GA", ctCode="241" },
                new countryItems { ctName = "GMB/GM", ctCode="220" },
                new countryItems { ctName = "GEO/GE", ctCode="995" },
                new countryItems { ctName = "DEU/DE", ctCode="49" },
                new countryItems { ctName = "GHA/GH", ctCode="223" },
                new countryItems { ctName = "GIB/GI", ctCode="350" },
                new countryItems { ctName = "GRC/GR", ctCode="30" },
                new countryItems { ctName = "GRL/GL", ctCode="299" },
                new countryItems { ctName = "GRD/GD", ctCode="1-473" },
                new countryItems { ctName = "GUM/GU", ctCode="1-671" },
                new countryItems { ctName = "GTM/GT", ctCode="502" },
                new countryItems { ctName = "GGY/GG", ctCode="44-1481" },
                new countryItems { ctName = "GIN/GN", ctCode="224" },
                new countryItems { ctName = "GNB/GW", ctCode="245" },
                new countryItems { ctName = "GUY/GY", ctCode="592" },
                new countryItems { ctName = "HTI/HT", ctCode="509" },
                new countryItems { ctName = "HND/HN", ctCode="504" },
                new countryItems { ctName = "HKG/HK", ctCode="852" },
                new countryItems { ctName = "HUN/HU", ctCode="36" },
                new countryItems { ctName = "ISL/IS", ctCode="354" },
                new countryItems { ctName = "IND/IN", ctCode="91" },
                new countryItems { ctName = "IDN/ID", ctCode="62" },
                new countryItems { ctName = "IRN/IR", ctCode="98" },
                new countryItems { ctName = "IRQ/IQ", ctCode="964" },
                new countryItems { ctName = "IRL/IE", ctCode="353" },
                new countryItems { ctName = "IMN/IM", ctCode="44-1624" },
                new countryItems { ctName = "ISR/IL", ctCode="972" },
                new countryItems { ctName = "ITA/IT", ctCode="39" },
                new countryItems { ctName = "CIV/CI", ctCode="225" },
                new countryItems { ctName = "JAM/JM", ctCode="1-876" },
                new countryItems { ctName = "JPN/JP", ctCode="81" },
                new countryItems { ctName = "JEY/JE", ctCode="44-1534" },
                new countryItems { ctName = "JOR/JO", ctCode="962" },
                new countryItems { ctName = "KAZ/KZ", ctCode="7" },
                new countryItems { ctName = "KEN/KE", ctCode="254" },
                new countryItems { ctName = "KIR/KI", ctCode="686" },
                new countryItems { ctName = "XKX/XK", ctCode="383" },
                new countryItems { ctName = "KWT/KW", ctCode="965" },
                new countryItems { ctName = "KGZ/KG", ctCode="996" },
                new countryItems { ctName = "LAO/LA", ctCode="856" },
                new countryItems { ctName = "LVA/LV", ctCode="371" },
                new countryItems { ctName = "LBN/LB", ctCode="961" },
                new countryItems { ctName = "LSO/LS", ctCode="266" },
                new countryItems { ctName = "LBR/LR", ctCode="231" },
                new countryItems { ctName = "LBY/LY", ctCode="218" },
                new countryItems { ctName = "LIE/LI", ctCode="423" },
                new countryItems { ctName = "LTU/LT", ctCode="370" },
                new countryItems { ctName = "LUX/LU", ctCode="352" },
                new countryItems { ctName = "MAC/MO", ctCode="853" },
                new countryItems { ctName = "MKD/MK", ctCode="389" },
                new countryItems { ctName = "MDG/MG", ctCode="261" },
                new countryItems { ctName = "MWI/MW", ctCode="265" },
                new countryItems { ctName = "MYS/MY", ctCode="60" },
                new countryItems { ctName = "MDV/MV", ctCode="960" },
                new countryItems { ctName = "MLI/ML", ctCode="223" },
                new countryItems { ctName = "MLT/MT", ctCode="356" },
                new countryItems { ctName = "MHL/MH", ctCode="692" },
                new countryItems { ctName = "MRT/MR", ctCode="222" },
                new countryItems { ctName = "MUS/MU", ctCode="230" },
                new countryItems { ctName = "MYT/YT", ctCode="262" },
                new countryItems { ctName = "MEX/MX", ctCode="52" },
                new countryItems { ctName = "FSM/FM", ctCode="691" },
                new countryItems { ctName = "MDA/MD", ctCode="373" },
                new countryItems { ctName = "MCO/MC", ctCode="377" },
                new countryItems { ctName = "MNG/MN", ctCode="976" },
                new countryItems { ctName = "MNE/ME", ctCode="382" },
                new countryItems { ctName = "MSR/MS", ctCode="1-664" },
                new countryItems { ctName = "MAR/MA", ctCode="212" },
                new countryItems { ctName = "MOZ/MZ", ctCode="258" },
                new countryItems { ctName = "MMR/MM", ctCode="95" },
                new countryItems { ctName = "NAM/NA", ctCode="264" },
                new countryItems { ctName = "NRU/NR", ctCode="674" },
                new countryItems { ctName = "NPL/NP", ctCode="977" },
                new countryItems { ctName = "NLD/NL", ctCode="31" },
                new countryItems { ctName = "ANT/AN", ctCode="599" },
                new countryItems { ctName = "NCL/NC", ctCode="687" },
                new countryItems { ctName = "NZL/NZ", ctCode="64" },
                new countryItems { ctName = "NIC/NI", ctCode="505" },
                new countryItems { ctName = "NER/NE", ctCode="227" },
                new countryItems { ctName = "NGA/NG", ctCode="234" },
                new countryItems { ctName = "NIU/NU", ctCode="683" },
                new countryItems { ctName = "PRK/KP", ctCode="850" },
                new countryItems { ctName = "MNP/MP", ctCode="1-670" },
                new countryItems { ctName = "NOR/NO", ctCode="47" },
                new countryItems { ctName = "OMN/OM", ctCode="968" },
                new countryItems { ctName = "PAK/PK", ctCode="92" },
                new countryItems { ctName = "PLW/PW", ctCode="680" },
                new countryItems { ctName = "PSE/PS", ctCode="970" },
                new countryItems { ctName = "PAN/PA", ctCode="507" },
                new countryItems { ctName = "PNG/PG", ctCode="675" },
                new countryItems { ctName = "PRY/PY", ctCode="595" },
                new countryItems { ctName = "PER/PE", ctCode="51" },
                new countryItems { ctName = "PHL/PH", ctCode="63" },
                new countryItems { ctName = "PCN/PN", ctCode="64" },
                new countryItems { ctName = "POL/PL", ctCode="48" },
                new countryItems { ctName = "PRT/PT", ctCode="351" },
                new countryItems { ctName = "PRI/PR", ctCode="1-787,1-939" },
                new countryItems { ctName = "QAT/QA", ctCode="974" },
                new countryItems { ctName = "COG/CG", ctCode="242" },
                new countryItems { ctName = "REU/RE", ctCode="262" },
                new countryItems { ctName = "ROU/RO", ctCode="40" },
                new countryItems { ctName = "RUS/RU", ctCode="7" },
                new countryItems { ctName = "RWA/RW", ctCode="250" },
                new countryItems { ctName = "BLM/BL", ctCode="590" },
                new countryItems { ctName = "SHN/SH", ctCode="290" },
                new countryItems { ctName = "KNA/KN", ctCode="1-869" },
                new countryItems { ctName = "LCA/LC", ctCode="1-758" },
                new countryItems { ctName = "MAF/MF", ctCode="590" },
                new countryItems { ctName = "SPM/PM", ctCode="508" },
                new countryItems { ctName = "VCT/VC", ctCode="1-784" },
                new countryItems { ctName = "WSM/WS", ctCode="685" },
                new countryItems { ctName = "SMR/SM", ctCode="378" },
                new countryItems { ctName = "STP/ST", ctCode="239" },
                new countryItems { ctName = "SAU/SA", ctCode="966" },
                new countryItems { ctName = "SEN/SN", ctCode="221" },
                new countryItems { ctName = "SRB/RS", ctCode="381" },
                new countryItems { ctName = "SYC/SC", ctCode="248" },
                new countryItems { ctName = "SLE/SL", ctCode="232" },
                new countryItems { ctName = "SGP/SG", ctCode="65" },
                new countryItems { ctName = "SXM/SX", ctCode="1-721" },
                new countryItems { ctName = "SVK/SK", ctCode="421" },
                new countryItems { ctName = "SVN/SI", ctCode="386" },
                new countryItems { ctName = "SLB/SB", ctCode="677" },
                new countryItems { ctName = "SOM/SO", ctCode="252" },
                new countryItems { ctName = "ZAF/ZA", ctCode="27" },
                new countryItems { ctName = "KOR/KR", ctCode="82" },
                new countryItems { ctName = "SSD/SS", ctCode="211" },
                new countryItems { ctName = "ESP/ES", ctCode="34" },
                new countryItems { ctName = "LKA/LK", ctCode="94" },
                new countryItems { ctName = "SDN/SD", ctCode="249" },
                new countryItems { ctName = "SUR/SR", ctCode="597" },
                new countryItems { ctName = "SJM/SJ", ctCode="47" },
                new countryItems { ctName = "SWZ/SZ", ctCode="268" },
                new countryItems { ctName = "SWE/SE", ctCode="46" },
                new countryItems { ctName = "CHE/CH", ctCode="41" },
                new countryItems { ctName = "SYR/SY", ctCode="963" },
                new countryItems { ctName = "TWN/TW", ctCode="886" },
                new countryItems { ctName = "TJK/TJ", ctCode="992" },
                new countryItems { ctName = "TZA/TZ", ctCode="255" },
                new countryItems { ctName = "THA/TH", ctCode="66" },
                new countryItems { ctName = "TGO/TG", ctCode="228" },
                new countryItems { ctName = "TKL/TK", ctCode="690" },
                new countryItems { ctName = "TON/TO", ctCode="676" },
                new countryItems { ctName = "TTO/TT", ctCode="1-868" },
                new countryItems { ctName = "TUN/TN", ctCode="216" },
                new countryItems { ctName = "TUR/TR", ctCode="90" },
                new countryItems { ctName = "TKM/TM", ctCode="993" },
                new countryItems { ctName = "TCA/TC", ctCode="1-649" },
                new countryItems { ctName = "TUV/TV", ctCode="688" },
                new countryItems { ctName = "VIR/VI", ctCode="1-340" },
                new countryItems { ctName = "UGA/UG", ctCode="256" },
                new countryItems { ctName = "UKR/UA", ctCode="380" },
                new countryItems { ctName = "ARE/AE", ctCode="971" },
                new countryItems { ctName = "GBR/GB", ctCode="44" },
                new countryItems { ctName = "USA/US", ctCode="1" },
                new countryItems { ctName = "URY/UY", ctCode="598" },
                new countryItems { ctName = "UZB/UZ", ctCode="998" },
                new countryItems { ctName = "VUT/VU", ctCode="678" },
                new countryItems { ctName = "VAT/VA", ctCode="379" },
                new countryItems { ctName = "VEN/VE", ctCode="58" },
                new countryItems { ctName = "VNM/VN", ctCode="84" },
                new countryItems { ctName = "WLF/WF", ctCode="681" },
                new countryItems { ctName = "ESH/EH", ctCode="212" },
                new countryItems { ctName = "YEM/YE", ctCode="967" },
                new countryItems { ctName = "ZMB/ZM", ctCode="260" },
                new countryItems { ctName = "ZWE/ZW", ctCode="263" },
            };

            ctList = ctList.OrderBy(i => i.ctName).ToList();
        }

        List<string> getList()
        {
            List<string> list = new List<string>();
            for (int i=0; i < ctList.Count; i++){
                list.Add(ctList[i].ctName);
            }
            return list;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menuAbout:
                    {
                        var intent = new Intent(this, typeof(aboutActivity));
                        StartActivity(intent);
                        return true;
                    }
                case Resource.Id.menuRateApp:
                    {
                        var intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://play.google.com/store/apps/details?id=beytullahakyuz.wpdirect"));
                        StartActivity(intent);
                        return true;
                    }
                case Resource.Id.menuTranslate:
                    {
                        try
                        {
                            var intent = new Intent();
                            intent.SetAction(Intent.ActionSendto);
                            intent.SetData(Android.Net.Uri.Parse("mailto:"));
                            intent.PutExtra(Intent.ExtraEmail, new string[] { "mrbeytullahakyuz@gmail.com", "beytullahakyuz@hotmail.com.tr" });
                            if (GetString(Resource.String.langCode) == "EN")
                            {
                                intent.PutExtra(Intent.ExtraSubject, "Translate App: Whatsapp Direct");
                                intent.PutExtra(Intent.ExtraText, "Translator Informations;\r\nFirst Name= \r\nLast Name= \r\n\r\n" +
                                      "Translate Information;\r\n" +
                                      "Target Language= \r\n" +
                                      "Country= \r\n" +
                                      "UTF-8 encoding error= \r\n" +
                                      "Whatsapp activity didn\'t found. Please, install Whatsapp and run again= \r\n" +
                                      "Clear= \r\n" +
                                      "Send= \r\n" +
                                      "Translate this app= \r\n" +
                                      "Rate this app= \r\n" +
                                      "About= \r\n" +
                                      "Please input message here= \r\n" +
                                      "Developer= \r\n" +
                                      "Website= \r\n" +
                                      "Thank you for your supported= \r\n" +
                                      "Thanks for translates= \r\n" +
                                      "Not found e-mail software!= \r\n"
                                    );
                            } else if (GetString(Resource.String.langCode) == "TR")
                            {
                                intent.PutExtra(Intent.ExtraSubject, "Uygulama Dil Çeviri: Whatsapp Direct");
                                intent.PutExtra(Intent.ExtraText, "Çevirici Bilgileri;\r\nAdınız= \r\nSoyadınız= \r\n\r\n" +
                                      "Çeviri Bilgileri;\r\n" +
                                      "Hedef Dil= \r\n" +
                                      "Ülke= \r\n" +
                                      "UTF8 kodlama hatası!= \r\n" +
                                      "Whatsapp formu bulunamadı. Lütfen, öncelikle whatsapp uygulamasını kurunuz ve uygulamayı tekrar çalıştırınız= \r\n" +
                                      "Temizle= \r\n" +
                                      "Gönder= \r\n" +
                                      "Dil çevirisi yap= \r\n" +
                                      "Uygulamayı oyla= \r\n" +
                                      "Hakkında= \r\n" +
                                      "Lütfen mesajınızı buraya giriniz= \r\n" +
                                      "Geliştirici= \r\n" +
                                      "Websitesi= \r\n" +
                                      "Desteğiniz için teşekkür ederim= \r\n" +
                                      "Çeviriler için teşekkürler= \r\n" +
                                      "Mail gönderme yazılımı bulunamadı!= \r\n"
                                    );
                            }

                            
                            StartActivity(intent);
                            Toast.MakeText(this, Resource.String.strThankyou, ToastLength.Long).Show();
                        }
                        catch (System.Exception)
                        {
                            Toast.MakeText(this, Resource.String.mailNotFound, ToastLength.Long).Show();
                        }
                        return true;
                    }

            }
            return base.OnOptionsItemSelected(item);
        }
    }
}