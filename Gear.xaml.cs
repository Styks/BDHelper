using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.IO;
using System.Data;



namespace BDHelper
{
    /// <summary>
    /// Логика взаимодействия для Gear.xaml
    /// </summary>
    public partial class Gear : Window
    {

        public string sclass;
        public Brush cimg;
        public int TempEnchLvl;
        public int TempCaphLvl;
        public string chWeapon;
        public string chSubWeapon;

        readonly CharacterState cs = new CharacterState();

        public Gear()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.MainWindow.Show();
        }

        private void Item_Icon_Load(string type, int id)
        {
            var cmd = new SqlCommand(@"select * from [" + type + "] where Id ='" + id + " ' ")
            {
                Connection = Base_Connect.Connection,
                CommandType = CommandType.Text
            };
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Byte[] img;
            img = (Byte[])ds.Tables[0].Rows[0]["Icon"];
            Image image = new Image();
            using (MemoryStream stream = new MemoryStream(img))
            {
                image.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
            Item_img.Source = image.Source;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cs.cdp = Convert.ToInt32(cDP_n.Content);
            cs.cap = Convert.ToInt32(cAP_n.Content);
            cs.caap = Convert.ToInt32(cAAP_n.Content);
            Sclass_lbl.Content = sclass;
            Cimg_img.Fill = cimg;
            if (sclass == "Shai") { cMistyHev_lbl.Visibility = Visibility.Visible; cMistyHev_n.Visibility = Visibility.Visible; cMistyHdp_lbl.Visibility = Visibility.Visible; cMistyHdp_n.Visibility = Visibility.Visible; cDelusLmvs_lbl.Visibility = Visibility.Visible; cDelusLmvs_n.Visibility = Visibility.Visible; cSunMoon_lbl.Visibility = Visibility.Visible; cSunMoon_n.Visibility = Visibility.Visible; }
            else { cMistyHev_lbl.Visibility = Visibility.Hidden; cMistyHev_n.Visibility = Visibility.Hidden; cMistyHdp_lbl.Visibility = Visibility.Hidden; cMistyHdp_n.Visibility = Visibility.Hidden; cDelusLmvs_lbl.Visibility = Visibility.Hidden; cDelusLmvs_n.Visibility = Visibility.Hidden; cSunMoon_lbl.Visibility = Visibility.Hidden; cSunMoon_n.Visibility = Visibility.Hidden; }
            ////////// Edit ComboBox
         // this.SelectGear_cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
         // this.SelectGear_cb.AutoCompleteSource = AutoCompleteSource.ListItems;
            //////////
            ItemCaph_cb.Visibility = Visibility.Hidden;
            Caph_lbl.Visibility = Visibility.Hidden;
            ItemEnch_cb.Visibility = Visibility.Hidden;
            Ench_lbl.Visibility = Visibility.Hidden;
        }
        private void FillCharacterState()
        {
            cAP_n.Content = Convert.ToString(cs.cap);
            cAAP_n.Content = Convert.ToString(cs.caap);
            cDP_n.Content = Convert.ToString(cs.cdp);
            cEvas_n.Content = Convert.ToString(cs.cev);
            cAcc_n.Content = Convert.ToString(cs.cacc);
            cSSFR_n.Content = Convert.ToString(cs.cRes1) + "%";
            cKBR_n.Content = Convert.ToString(cs.cRes2) + "%";
            cGrapR_n.Content = Convert.ToString(cs.cRes3) + "%";
            cKFR_n.Content = Convert.ToString(cs.cRes4) + "%";
            cDR_n.Content = Convert.ToString(cs.cDR);
            cHP_n.Content = Convert.ToString(cs.cMaxHP);
            cMP_n.Content = Convert.ToString(cs.cMaxMP);
            cStamina_n.Content = Convert.ToString(cs.cMaxST);
            Weight_n.Content = Convert.ToString(cs.cWeight);
            cHDR_n.Content = Convert.ToString(cs.chdr);
            cHE_n.Content = Convert.ToString(cs.chev);
            cMvS_n.Content = Convert.ToString(cs.cmvs);
            cCR_n.Content = Convert.ToString(cs.ccr);
            cHAP_n.Content = Convert.ToString(cs.chap);
            cAtkSpeed_n.Content = Convert.ToString(cs.cAtkSpeed);
            cCastSpeed_n.Content = Convert.ToString(cs.cCastSpeed);
            cHPR_n.Content = Convert.ToString(cs.chpr);
            cMPR_n.Content = Convert.ToString(cs.cmpr);
            cLuck_n.Content = Convert.ToString(cs.cluck);
            cEDA_n.Content = Convert.ToString(cs.ceda);
            cEDH_n.Content = Convert.ToString(cs.cedh);
            cEAPa_n.Content = Convert.ToString(cs.ceapa);
            cExtraDamKama_n.Content = Convert.ToString(cs.cedKama);
            cADtDemiH_n.Content = Convert.ToString(cs.cADtDemiH);
            cEDtAExcHumanAndDemi_n.Content = Convert.ToString(cs.cADtoAllWithExcept);
            cBidding_n.Content = Convert.ToString(cs.cBidding) + "%";
            cSpiritRage_n.Content = Convert.ToString(cs.cSpiritRage) + "%";
            cEDtoBack_n.Content = Convert.ToString(cs.cEDtoBack) + "%";
            cDFM_n.Content = Convert.ToString(cs.cdfm) + "%";
            cMistyHev_n.Content = Convert.ToString(cs.shaiEv) + "%";
            cMistyHdp_n.Content = Convert.ToString(cs.shaiDP) + "%";
            cDelusLmvs_n.Content = Convert.ToString(cs.shaiMvs) + "%";
            cSunMoon_n.Content = Convert.ToString(cs.shaiSpeed) + "%";
            cHPRecoveryChance_n.Content = Convert.ToString(cs.cHPrecoveryChance);
            cIgnoreResistance_n.Content = Convert.ToString(cs.cResistIgnore) + "%";
            cSpecialAttackED_n.Content = Convert.ToString(cs.cSpecialAttackDam) + "%";
            cSpecialAttackEvRate_n.Content = Convert.ToString(cs.cSpecialAttackEv) + "%";
            cCastSpeedRate_n.Content = cs.cCastSpeedRate.ToString() + "%";
            cAtkSpeedRate_n.Content = cs.cAtkSpeedRate.ToString() + "%";
            cAlchCookTime_n.Content = cs.cAlchCookTime.ToString();
            cProcessingRate_n.Content = cs.cProccesingRate.ToString() + "%";
            cGathering_n.Content = cs.cGathering.ToString();
            cFishing_n.Content = cs.cFishing.ToString();
            cGathDropRate_n.Content = cs.cGathDropRate.ToString() + "%";
        }

        private void ItemStatClear()
        {
            iAP_n.Content = "0"; //AP
            iDP_n.Content = "0"; //DP
            iEvas_n.Content = "0"; //Evasion
            iAcc_n.Content = "0"; //Accuracy
            iRes_n.Content = "0%"; //All Resists
            iDR_n.Content = "0"; // Damage Reduction
            iHP_n.Content = "0"; // Max HP
            iWeight_n.Content = "0"; // Max Weight
            iMP_n.Content = "0"; //Max MP
            iST_n.Content = "0"; //Max stamina
            iSSFR_n.Content = "0%"; // SSF Resist
            iKBR_n.Content = "0%"; // KB Resist
            iGrapR_n.Content = "0%"; // Graple Resist
            iKFR_n.Content = "0%"; //KF Resist
            iHEV_n.Content = "0"; //Hiden Evasion
            iHDR_n.Content = "0"; //Hiden Damage Reduction
            iAtkSpeed_n.Content = "0"; // Attack speed
            iCastSpeed_n.Content = "0"; //Cast speed
            iMVS_n.Content = "0"; // Movement speed
            iCrit_n.Content = "0"; // Critical rate
            iExtraDamKama_n.Content = "0"; //Extra Damage to Kamasylvians
            iEDtA_n.Content = "0"; // Extra Damage to All Species
            iEAPa_n.Content = "0"; // Extra AP against monters
            iMPR_n.Content = "0"; // MP Recovery
            iHPR_n.Content = "0"; // HP Recovery
            iLuck_n.Content = "0"; // Luck
            iEDH_n.Content = "0"; //Extra damage to Humans
            iADtDemiH_n.Content = "0"; // Additional damage to Demihumans
            iEDtAExcHumanAndDemi_n.Content = "0"; //Extra damage to All Species Except Humans and Demihumans
            iSpiritRage_n.Content = "0%"; // Black Spirit's Rage
            iBidding_n.Content = "0%"; //Marketplace Bidding Success Rate
            iEDtoBack_n.Content = "0%"; // Extra damage to back
            iHPRecoveryChance_n.Content = "0";
            iIgnoreResistance_n.Content = "0%";
            iSpecialAttackED_n.Content = "0%";
            iSpecialAttackEvRate_n.Content = "0%";
            iHAP_n.Content = "0";
            iCastSpeedRate_n.Content = "0%";
            iAtkSpeedRate_n.Content = "0%";
            iAlchCookTime_n.Content = "0";
            iProcessingRate_n.Content = "0%";
            iGathering_n.Content = "0";
            iFishing_n.Content = "0";
            iGathDropRate_n.Content = "0%";
        }

        //Item load procedurs
        private void LoadBelts() //Belt
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"select * from Belts";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            SelectGear_cb.DisplayMemberPath = "Name";
            SelectGear_cb.SelectedValuePath = "Id";        
            //SelectGear_cb.DataSource = ds.Tables[0];
            //SelectGear_cb.DisplayMember = "Name";
            //SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Belts", cs.beltId);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            SelectGear_cb.SelectedIndex = cs.beltId;
            LoadItemEnch_cb();
            LoadItemCaph_cb();
        }

        private void LoadNeck() //Neck
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"select * from Neck";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            SelectGear_cb.DisplayMemberPath = "Name";
            SelectGear_cb.SelectedValuePath = "Id";
            // SelectGear_cb.DataSource = ds.Tables[0];
            // SelectGear_cb.DisplayMember = "Name";
            // SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Neck", cs.neckId);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            SelectGear_cb.SelectedIndex = cs.neckId;
            LoadItemEnch_cb();
            LoadItemCaph_cb();
        }

        private void Load1Ring() //First ring
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"select * from Rings";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            SelectGear_cb.DisplayMemberPath = "Name";
            SelectGear_cb.SelectedValuePath = "Id";
           // SelectGear_cb.DataSource = ds.Tables[0];
           // SelectGear_cb.DisplayMember = "Name";
           // SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Rings", cs.ring1Id);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            SelectGear_cb.SelectedIndex = cs.ring1Id;
            LoadItemEnch_cb();
            LoadItemCaph_cb();
        }

        private void Load2Ring() //Second ring
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"select * from Rings";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            SelectGear_cb.DisplayMemberPath = "Name";
            SelectGear_cb.SelectedValuePath = "Id";
           // SelectGear_cb.DataSource = ds.Tables[0];
           // SelectGear_cb.DisplayMember = "Name";
           // SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Rings", cs.ring2Id);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            SelectGear_cb.SelectedIndex = cs.ring2Id;
            LoadItemEnch_cb();
            LoadItemCaph_cb();
        }

        private void Load1Earring() //First earring
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"select * from Earrings";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            SelectGear_cb.DisplayMemberPath = "Name";
            SelectGear_cb.SelectedValuePath = "Id";
            // SelectGear_cb.DataSource = ds.Tables[0];
            // SelectGear_cb.DisplayMember = "Name";
            // SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Earrings", cs.ear1Id);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            SelectGear_cb.SelectedIndex = cs.ear1Id;
            LoadItemEnch_cb();
            LoadItemCaph_cb();
        }

        private void Load2Earring() //Second earring
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"select * from Earrings";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            SelectGear_cb.DisplayMemberPath = "Name";
            SelectGear_cb.SelectedValuePath = "Id";
           // SelectGear_cb.DataSource = ds.Tables[0];
           // SelectGear_cb.DisplayMember = "Name";
           // SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Earrings", cs.ear2Id);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            SelectGear_cb.SelectedIndex = cs.ear2Id;
            LoadItemEnch_cb();
            LoadItemCaph_cb();
        }

        private void LoadArmor() //Armor
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"select * from Armors";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            SelectGear_cb.DisplayMemberPath = "Name";
            SelectGear_cb.SelectedValuePath = "Id";
            // SelectGear_cb.DataSource = ds.Tables[0];
            // SelectGear_cb.DisplayMember = "Name";
            // SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Armors", cs.armId);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            SelectGear_cb.SelectedIndex = cs.armId;
            LoadItemEnch_cb();
            LoadItemCaph_cb();
        }

        private void LoadHelmet() // Helmet
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"select * from Helmets";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            SelectGear_cb.DisplayMemberPath = "Name";
            SelectGear_cb.SelectedValuePath = "Id";
           // SelectGear_cb.DataSource = ds.Tables[0];
           // SelectGear_cb.DisplayMember = "Name";
           // SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Helmets", cs.helId);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            SelectGear_cb.SelectedIndex = cs.helId;
            LoadItemEnch_cb();
            LoadItemCaph_cb();
        } 

        private void LoadGloves() // Gloves
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"select * from Gloves";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            SelectGear_cb.DisplayMemberPath = "Name";
            SelectGear_cb.SelectedValuePath = "Id";
            // SelectGear_cb.DataSource = ds.Tables[0];
            // SelectGear_cb.DisplayMember = "Name";
            // SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Gloves", cs.glovId);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            SelectGear_cb.SelectedIndex = cs.glovId;
            LoadItemEnch_cb();
            LoadItemCaph_cb();
        }

        private void LoadShoes() // Shoes
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"select * from Shoes";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            SelectGear_cb.DisplayMemberPath = "Name";
            SelectGear_cb.SelectedValuePath = "Id";
           // SelectGear_cb.DataSource = ds.Tables[0];
           // SelectGear_cb.DisplayMember = "Name";
           // SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Shoes", cs.shId);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            SelectGear_cb.SelectedIndex = cs.shId;
            LoadItemEnch_cb();
            LoadItemCaph_cb();
        }

        private void LoadAW() // AW
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"select * from [" + sclass + " Awakening Weapons]";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            SelectGear_cb.DisplayMemberPath = "Name";
            SelectGear_cb.SelectedValuePath = "Id";
           // SelectGear_cb.DataSource = ds.Tables[0];
           // SelectGear_cb.DisplayMember = "Name";
           // SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load(sclass.ToString() + " Awakening Weapons", cs.awkId);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            SelectGear_cb.SelectedIndex = cs.awkId;

            LoadItemEnch_cb();
            LoadItemCaph_cb();
        }
        private void LoadMW() // MW
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"select * from [" + chWeapon + " Main Weapon]";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            SelectGear_cb.DisplayMemberPath = "Name";
            SelectGear_cb.SelectedValuePath = "Id";
            // SelectGear_cb.DataSource = ds.Tables[0];
            // SelectGear_cb.DisplayMember = "Name";
            // SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load(chWeapon.ToString() + " Main Weapon", cs.mwId);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            SelectGear_cb.SelectedIndex = cs.mwId;

            LoadItemEnch_cb();
            LoadItemCaph_cb();
        }
        private void LoadSW() // SW
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"select * from [" + chSubWeapon + " Sub-Weapons]";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            SelectGear_cb.DisplayMemberPath = "Name";
            SelectGear_cb.SelectedValuePath = "Id";
           // SelectGear_cb.DataSource = ds.Tables[0];
           // SelectGear_cb.DisplayMember = "Name";
           // SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load(chSubWeapon.ToString() + " Sub-Weapons", cs.swId);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            SelectGear_cb.SelectedIndex = cs.swId;
            LoadItemEnch_cb();
            LoadItemCaph_cb();
        }

        private void LoadAS() // Alchemy Stone
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"select * from [Alchemy Stones]";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            SelectGear_cb.DisplayMemberPath = "Name";
            SelectGear_cb.SelectedValuePath = "Id";
           // SelectGear_cb.DataSource = ds.Tables[0];
           // SelectGear_cb.DisplayMember = "Name";
           // SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Alchemy Stones", cs.asId);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            SelectGear_cb.SelectedIndex = cs.asId;
            LoadItemEnch_cb();
            LoadItemCaph_cb();
        }

        //Lvl Bonus
  /*      private void DpLvl_cb_CheckedChanged(object sender, EventArgs e)
        {
            int lvlDP = 1;
            if (dpLvl_cb.Checked == true)
            {
                cDP_n.Text = Convert.ToString(cs.cdp + lvlDP);
            }
            else
            {
                cDP_n.Text = Convert.ToString(cs.cdp - lvlDP);
            }
            cs.cdp = Convert.ToInt32(cDP_n.Text);
        }

        private void ApLvl_cb_CheckedChanged(object sender, EventArgs e)
        {
            int lvlAP = 1;
            int lvlAAP = 1;
            if (apLvl_cb.Checked == true)
            {
                cAP_n.Text = Convert.ToString(cs.cap + lvlAP);
                cAAP_n.Text = Convert.ToString(cs.caap + lvlAAP);
            }
            else
            {
                cAP_n.Text = Convert.ToString(cs.cap - lvlAP);
                cAAP_n.Text = Convert.ToString(cs.caap - lvlAAP);
            }
            cs.cap = Convert.ToInt32(cAP_n.Text);
            cs.caap = Convert.ToInt32(cAAP_n.Text);
        } */


        //Item buttons
        private void Belt_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 1;
            LoadBelts();
        }
        private void Necklace_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 2;
            LoadNeck();
        }
        private void Ring1_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 3;
            Load1Ring();
        }
        private void Ring2_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 4;
            Load2Ring();
        }
        private void Earring1_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 5;
            Load1Earring();
        }
        private void Earring2_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 6;
            Load2Earring();
        }
        private void Armour_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 7;
            LoadArmor();

        }
        private void Helmet_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 8;
            LoadHelmet();
        }
        private void Gloves_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 9;
            LoadGloves();
        }
        private void Boots_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 10;
            LoadShoes();
        }
        private void AW_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 11;
            LoadAW();
        }
        private void MW_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 12;
            LoadMW();
        }
        private void SW_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 13;
            LoadSW();
        }
        private void AS_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 14;
            LoadAS();
        }

        private void SelectGear_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemStatClear();
            SqlCommand cmd = Base_Connect.Connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (cs.sgn == 1) //Belt
            {
                cmd.CommandText = "select * from Belts where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cs.beltDefap = Convert.ToInt32(dr["AP"]);
                    cs.beltDefdp = Convert.ToInt32(dr["DP"]);
                    cs.beltDefev = Convert.ToInt32(dr["Evasion"]);
                    cs.beltDefacc = Convert.ToInt32(dr["Accuracy"]);
                    cs.beltDefResis = Convert.ToInt32(dr["AllResist"]);
                    cs.beltDefDR = Convert.ToInt32(dr["DR"]);
                    cs.beltDefHP = Convert.ToInt32(dr["MaxHP"]);
                    cs.beltDefWeight = Convert.ToInt32(dr["Weight"]);
                    cs.beltEnch = Convert.ToBoolean(dr["Ench"]);
                    cs.beltDefSpiritRage = Convert.ToInt32(dr["BlackSpirit"]);
                    cs.beltDefAPagainst = Convert.ToInt32(dr["ApAgainst"]);
                    cs.beltSB = Convert.ToInt32(dr["SetBonus"]);
                }
                LoadItemEnch_cb();
                LoadItemCaph_cb();
                cs.Type = "Belts";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                //Belt_btn.BackgroundImage = Item_image.Image;
                cs.BeltState();
                if (cs.beltEnch == false) Belt_btn.Content = "";

                if (cs.beltEnch == true && SelectGear_cb.SelectedIndex == cs.beltId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.beltEnchLvl = TempEnchLvl; }
                if (cs.beltEnch == true && SelectGear_cb.SelectedIndex != cs.beltId) { ItemEnch_cb.SelectedIndex = 0; cs.beltEnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.beltEnch == false) { cs.beltEnchLvl = 0; }

                iAP_n.Content = cs.beltap.ToString();
                iDP_n.Content = cs.beltdp.ToString();
                iEvas_n.Content = cs.beltev.ToString();
                iAcc_n.Content = cs.beltacc.ToString();
                iRes_n.Content = cs.beltResis.ToString();
                iDR_n.Content = cs.beltDR.ToString();
                iHP_n.Content = cs.beltHP.ToString();
                iWeight_n.Content = cs.beltWeight.ToString();
                iSpiritRage_n.Content = Convert.ToString(cs.beltSpiritRage) + "%";
                iEAPa_n.Content = cs.beltAPagaingst.ToString();

                cs.beltId = SelectGear_cb.SelectedIndex;
            } //Belt
            if (cs.sgn == 2) //Neck
            {

                cmd.CommandText = "select * from Neck where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cs.neckDefap = Convert.ToInt32(dr["AP"]);
                    cs.neckDefdp = Convert.ToInt32(dr["DP"]);
                    cs.neckDefev = Convert.ToInt32(dr["Evasion"]);
                    cs.neckDefacc = Convert.ToInt32(dr["Accuracy"]);
                    cs.neckDefAllRes = Convert.ToInt32(dr["AllRes"]);
                    cs.neckDefDR = Convert.ToInt32(dr["DR"]);
                    cs.neckDefSSF = Convert.ToInt32(dr["SSFRes"]);
                    cs.neckDefKB = Convert.ToInt32(dr["KBRes"]);
                    cs.neckDefG = Convert.ToInt32(dr["GrapRes"]);
                    cs.neckDefKF = Convert.ToInt32(dr["KFRes"]);
                    cs.neckDefHP = Convert.ToInt32(dr["MaxHP"]);
                    cs.neckEnch = Convert.ToBoolean(dr["Ench"]);
                    cs.neckDefSpiritRage = Convert.ToInt32(dr["BlackSpirit"]);
                    cs.neckDefAPagainst = Convert.ToInt32(dr["ApAgainst"]);
                    cs.neckDefKamaDamage = Convert.ToInt32(dr["KamaDamage"]);
                    cs.neckDefBackDamage = Convert.ToInt32(dr["BackDamage"]);
                    cs.neckSB = Convert.ToInt32(dr["SetBonus"]);
                }
                LoadItemEnch_cb();
                LoadItemCaph_cb();
                cs.Type = "Neck";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                //Necklace_btn.BackgroundImage = Item_image.Image;
                cs.NeckState();
                if (cs.neckEnch == false) Necklace_btn.Content = "";

                if (cs.neckEnch == true && SelectGear_cb.SelectedIndex == cs.neckId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.neckEnchLvl = TempEnchLvl; }
                if (cs.neckEnch == true && SelectGear_cb.SelectedIndex != cs.neckId) { ItemEnch_cb.SelectedIndex = 0; cs.neckEnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.neckEnch == false) { cs.neckEnchLvl = 0; }

                iAP_n.Content = cs.neckap.ToString();
                iDP_n.Content = cs.neckdp.ToString();
                iEvas_n.Content = cs.neckev.ToString();
                iAcc_n.Content = cs.neckacc.ToString();
                iRes_n.Content = cs.neckAllRes.ToString() + "%";
                iDR_n.Content = cs.neckDR.ToString();
                iSSFR_n.Content = cs.neckSSF.ToString() + "%";
                iKBR_n.Content = cs.neckKB.ToString() + "%";
                iGrapR_n.Content = cs.neckG.ToString() + "%";
                iKFR_n.Content = cs.neckKF.ToString() + "%";
                iHP_n.Content = cs.neckHP.ToString();
                iSpiritRage_n.Content = Convert.ToString(cs.neckSpiritRage) + "%";
                iEAPa_n.Content = cs.neckAPagaingst.ToString();
                iExtraDamKama_n.Content = cs.neckKamaDamage.ToString();
                iEDtoBack_n.Content = cs.neckBackDamage.ToString() + "%";

                cs.neckId = SelectGear_cb.SelectedIndex;
            } //Necklace            
            if (cs.sgn == 3) //Ring 1
            {
                cmd.CommandText = "select * from Rings where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cs.ring1Defap = Convert.ToInt32(dr["AP"]);
                    cs.ring1Defdp = Convert.ToInt32(dr["DP"]);
                    cs.ring1Defev = Convert.ToInt32(dr["Evasion"]);
                    cs.ring1Defacc = Convert.ToInt32(dr["Accuracy"]);
                    cs.ring1DefDR = Convert.ToInt32(dr["DR"]);
                    cs.ring1DefHP = Convert.ToInt32(dr["MaxHP"]);
                    cs.ring1DefMP = Convert.ToInt32(dr["MaxMP"]);
                    cs.ring1DefST = Convert.ToInt32(dr["MaxST"]);
                    cs.ring1Ench = Convert.ToBoolean(dr["Ench"]);
                    cs.ring1DefHEv = Convert.ToInt32(dr["HEv"]);
                    cs.ring1DefAPagainst = Convert.ToInt32(dr["ApAgainst"]);
                    cs.ring1DefKamaDamage = Convert.ToInt32(dr["KamaDamage"]);
                    cs.ring1DefDamageHumans = Convert.ToInt32(dr["HumanDamage"]);
                    cs.ring1DefDamageDemihumans = Convert.ToInt32(dr["DemiHumanDamage"]);
                    cs.ring1DefDamageAllExcept = Convert.ToInt32(dr["DamAllExHuman"]);
                    cs.ring1DefBidding = Convert.ToInt32(dr["MarketBidding"]);
                    cs.ring1DefSpiritRage = Convert.ToInt32(dr["BlackSpirit"]);
                    cs.ring1SB = Convert.ToInt32(dr["SetBonus"]);
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = "Rings";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                //Ring1_btn.BackgroundImage = Item_image.Image;
                cs.Ring1State();
                if (cs.ring1Ench == false) Ring1_btn.Content = "";

                if (cs.ring1Ench == true && SelectGear_cb.SelectedIndex == cs.ring1Id) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.ring1EnchLvl = TempEnchLvl; }
                if (cs.ring1Ench == true && SelectGear_cb.SelectedIndex != cs.ring1Id) { ItemEnch_cb.SelectedIndex = 0; cs.ring1EnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.ring1Ench == false) { cs.ring1EnchLvl = 0; }


                iAP_n.Content = cs.ring1ap.ToString();
                iDP_n.Content = cs.ring1dp.ToString();
                iEvas_n.Content = cs.ring1ev.ToString();
                iAcc_n.Content = cs.ring1acc.ToString();
                iDR_n.Content = cs.ring1DR.ToString();
                iHP_n.Content = cs.ring1HP.ToString();
                iMP_n.Content = cs.ring1MP.ToString();
                iST_n.Content = cs.ring1ST.ToString();
                iHEV_n.Content = cs.ring1HEv.ToString();
                iEAPa_n.Content = cs.ring1APagaingst.ToString();
                iExtraDamKama_n.Content = cs.ring1KamaDamage.ToString();
                iEDH_n.Content = cs.ring1DamageHumans.ToString();
                iADtDemiH_n.Content = cs.ring1DamageDemihumans.ToString();
                iEDtAExcHumanAndDemi_n.Content = Convert.ToString(cs.ring1DamageAllExcept);
                iBidding_n.Content = Convert.ToString(cs.ring1Bidding) + "%";
                iSpiritRage_n.Content = Convert.ToString(cs.ring1SpiritRage) + "%";

                cs.ring1Id = SelectGear_cb.SelectedIndex;
            } //Ring1
            if (cs.sgn == 4) //Ring 2
            {
                cmd.CommandText = "select * from Rings where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cs.ring2Defap = Convert.ToInt32(dr["AP"]);
                    cs.ring2Defdp = Convert.ToInt32(dr["DP"]);
                    cs.ring2Defev = Convert.ToInt32(dr["Evasion"]);
                    cs.ring2Defacc = Convert.ToInt32(dr["Accuracy"]);
                    cs.ring2DefDR = Convert.ToInt32(dr["DR"]);
                    cs.ring2DefHP = Convert.ToInt32(dr["MaxHP"]);
                    cs.ring2DefMP = Convert.ToInt32(dr["MaxMP"]);
                    cs.ring2DefST = Convert.ToInt32(dr["MaxST"]);
                    cs.ring2Ench = Convert.ToBoolean(dr["Ench"]);
                    cs.ring2DefHEv = Convert.ToInt32(dr["HEv"]);
                    cs.ring2DefAPagainst = Convert.ToInt32(dr["ApAgainst"]);
                    cs.ring2DefKamaDamage = Convert.ToInt32(dr["KamaDamage"]);
                    cs.ring2DefDamageHumans = Convert.ToInt32(dr["HumanDamage"]);
                    cs.ring2DefDamageDemihumans = Convert.ToInt32(dr["DemiHumanDamage"]);
                    cs.ring2DefDamageAllExcept = Convert.ToInt32(dr["DamAllExHuman"]);
                    cs.ring2DefBidding = Convert.ToInt32(dr["MarketBidding"]);
                    cs.ring2DefSpiritRage = Convert.ToInt32(dr["BlackSpirit"]);
                    cs.ring2SB = Convert.ToInt32(dr["SetBonus"]);
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = "Rings";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                //Ring2_btn.BackgroundImage = Item_image.Image;
                cs.Ring2State();
                if (cs.ring2Ench == false) Ring2_btn.Content = "";

                if (cs.ring2Ench == true && SelectGear_cb.SelectedIndex == cs.ring2Id) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.ring2EnchLvl = TempEnchLvl; }
                if (cs.ring2Ench == true && SelectGear_cb.SelectedIndex != cs.ring2Id) { ItemEnch_cb.SelectedIndex = 0; cs.ring2EnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.ring2Ench == false) { cs.ring2EnchLvl = 0; }


                iAP_n.Content = cs.ring2ap.ToString();
                iDP_n.Content = cs.ring2dp.ToString();
                iEvas_n.Content = cs.ring2ev.ToString();
                iAcc_n.Content = cs.ring2acc.ToString();
                iDR_n.Content = cs.ring2DR.ToString();
                iHP_n.Content = cs.ring2HP.ToString();
                iMP_n.Content = cs.ring2MP.ToString();
                iST_n.Content = cs.ring2ST.ToString();
                iHEV_n.Content = cs.ring2HEv.ToString();
                iEAPa_n.Content = cs.ring2APagaingst.ToString();
                iExtraDamKama_n.Content = cs.ring2KamaDamage.ToString();
                iEDH_n.Content = cs.ring2DamageHumans.ToString();
                iADtDemiH_n.Content = cs.ring2DamageDemihumans.ToString();
                iEDtAExcHumanAndDemi_n.Content = Convert.ToString(cs.ring2DamageAllExcept);
                iBidding_n.Content = Convert.ToString(cs.ring2Bidding) + "%";
                iSpiritRage_n.Content = Convert.ToString(cs.ring2SpiritRage) + "%";

                cs.ring2Id = SelectGear_cb.SelectedIndex;
            }//Ring 2
            if (cs.sgn == 5) //Ear1
            {
                cmd.CommandText = "select * from Earrings where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cs.ear1Defap = Convert.ToInt32(dr["AP"]);
                    cs.ear1Defdp = Convert.ToInt32(dr["DP"]);
                    cs.ear1Defev = Convert.ToInt32(dr["Evasion"]);
                    cs.ear1Defacc = Convert.ToInt32(dr["Accuracy"]);
                    cs.ear1DefDR = Convert.ToInt32(dr["DR"]);
                    cs.ear1DefHP = Convert.ToInt32(dr["MaxHP"]);
                    cs.ear1DefMP = Convert.ToInt32(dr["MaxMP"]);
                    cs.ear1DefST = Convert.ToInt32(dr["MaxST"]);
                    cs.ear1Ench = Convert.ToBoolean(dr["Ench"]);
                    cs.ear1DefSpiritRage = Convert.ToInt32(dr["BlackSpirit"]);
                    cs.ear1DefAPagainst = Convert.ToInt32(dr["ApAgainst"]);
                    cs.ear1DefKamaDamage = Convert.ToInt32(dr["KamaDamage"]);
                    cs.ear1SB = Convert.ToInt32(dr["SetBonus"]);
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = "Earrings";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                //Earring1_btn.BackgroundImage = Item_image.Image;
                cs.Earring1State();
                if (cs.ear1Ench == false) Earring1_btn.Content = "";

                if (cs.ear1Ench == true && SelectGear_cb.SelectedIndex == cs.ear1Id) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.ear1EnchLvl = TempEnchLvl; }
                if (cs.ear1Ench == true && SelectGear_cb.SelectedIndex != cs.ear1Id) { ItemEnch_cb.SelectedIndex = 0; cs.ear1EnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.ear1Ench == false) { cs.ear1EnchLvl = 0; }


                iAP_n.Content = cs.ear1ap.ToString();
                iDP_n.Content = cs.ear1dp.ToString();
                iEvas_n.Content = cs.ear1ev.ToString();
                iAcc_n.Content = cs.ear1acc.ToString();
                iDR_n.Content = cs.ear1DR.ToString();
                iHP_n.Content = cs.ear1HP.ToString();
                iMP_n.Content = cs.ear1MP.ToString();
                iST_n.Content = cs.ear1ST.ToString();
                iSpiritRage_n.Content = Convert.ToString(cs.ear1SpiritRage) + "%";
                iEAPa_n.Content = cs.ear1APagaingst.ToString();
                iExtraDamKama_n.Content = cs.ear1KamaDamage.ToString();

                cs.ear1Id = SelectGear_cb.SelectedIndex;
            } //Earring 1
            if (cs.sgn == 6) //Ear2
            {
                cmd.CommandText = "select * from Earrings where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cs.ear2Defap = Convert.ToInt32(dr["AP"]);
                    cs.ear2Defdp = Convert.ToInt32(dr["DP"]);
                    cs.ear2Defev = Convert.ToInt32(dr["Evasion"]);
                    cs.ear2Defacc = Convert.ToInt32(dr["Accuracy"]);
                    cs.ear2DefDR = Convert.ToInt32(dr["DR"]);
                    cs.ear2DefHP = Convert.ToInt32(dr["MaxHP"]);
                    cs.ear2DefMP = Convert.ToInt32(dr["MaxMP"]);
                    cs.ear2DefST = Convert.ToInt32(dr["MaxST"]);
                    cs.ear2Ench = Convert.ToBoolean(dr["Ench"]);
                    cs.ear2DefSpiritRage = Convert.ToInt32(dr["BlackSpirit"]);
                    cs.ear2DefAPagainst = Convert.ToInt32(dr["ApAgainst"]);
                    cs.ear2DefKamaDamage = Convert.ToInt32(dr["KamaDamage"]);
                    cs.ear2SB = Convert.ToInt32(dr["SetBonus"]);
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = "Earrings";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                //Earring2_btn.BackgroundImage = Item_image.Image;
                cs.Earring2State();
                if (cs.ear2Ench == false) Earring2_btn.Content = "";

                if (cs.ear2Ench == true && SelectGear_cb.SelectedIndex == cs.ear2Id) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.ear2EnchLvl = TempEnchLvl; }
                if (cs.ear2Ench == true && SelectGear_cb.SelectedIndex != cs.ear2Id) { ItemEnch_cb.SelectedIndex = 0; cs.ear2EnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.ear2Ench == false) { cs.ear2EnchLvl = 0; }


                iAP_n.Content = cs.ear2ap.ToString();
                iDP_n.Content = cs.ear2dp.ToString();
                iEvas_n.Content = cs.ear2ev.ToString();
                iAcc_n.Content = cs.ear2acc.ToString();
                iDR_n.Content = cs.ear2DR.ToString();
                iHP_n.Content = cs.ear2HP.ToString();
                iMP_n.Content = cs.ear2MP.ToString();
                iST_n.Content = cs.ear2ST.ToString();
                iSpiritRage_n.Content = Convert.ToString(cs.ear2SpiritRage) + "%";
                iEAPa_n.Content = cs.ear2APagaingst.ToString();
                iExtraDamKama_n.Content = cs.ear2KamaDamage.ToString();

                cs.ear2Id = SelectGear_cb.SelectedIndex;
            } //Earring 2
            if (cs.sgn == 7)
            {
                cmd.CommandText = "select * from Armors where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cs.armDefdp = Convert.ToInt32(dr["DP"]);
                    cs.armDefev = Convert.ToInt32(dr["Evasion"]);
                    cs.armDefhev = Convert.ToInt32(dr["HEvasion"]);
                    cs.armDefdr = Convert.ToInt32(dr["DR"]);
                    cs.armDefhdr = Convert.ToInt32(dr["HDR"]);
                    cs.armDefHP = Convert.ToInt32(dr["MaxHP"]);
                    cs.armDefMP = Convert.ToInt32(dr["MaxMP"]);
                    cs.armEnch = Convert.ToBoolean(dr["Ench"]);
                    cs.armIsBoss = Convert.ToBoolean(dr["IsBossItem"]);
                    cs.armDefSSFRes = Convert.ToInt32(dr["SSFRes"]);
                    cs.armDefWeight = Convert.ToInt32(dr["WeightLimit"]);
                    cs.armDefAcc = Convert.ToInt32(dr["Accuracy"]);
                    cs.armSB = Convert.ToInt32(dr["SetBonus"]);
                    cs.armDefHPRecovery = Convert.ToInt32(dr["HPRecovery"]);
                    cs.armDefMPRecovery = Convert.ToInt32(dr["MPRecovery"]);
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = "Armors";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                //Armour_btn.BackgroundImage = Item_image.Image;
                cs.ArmorState();
                if (cs.armEnch == false) Armour_btn.Content = "";

                if (cs.armEnch == true && SelectGear_cb.SelectedIndex == cs.armId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.armEnchLvl = TempEnchLvl; }
                if (cs.armEnch == true && SelectGear_cb.SelectedIndex != cs.armId) { ItemEnch_cb.SelectedIndex = 0; cs.armEnchLvl = 0; TempEnchLvl = 0; ItemCaph_cb.SelectedIndex = 0; cs.armCaphLvl = 0; TempCaphLvl = 0; }
                else if (cs.armEnch == false) { cs.armEnchLvl = 0; cs.armCaphLvl = 0; }


                iDP_n.Content = cs.armdp.ToString();
                iEvas_n.Content = cs.armev.ToString();
                iHEV_n.Content = cs.armhev.ToString();
                iDR_n.Content = cs.armdr.ToString();
                iHDR_n.Content = cs.armhdr.ToString();
                iHP_n.Content = cs.armHP.ToString();
                iMP_n.Content = cs.armMP.ToString();
                iSSFR_n.Content = cs.armSSFRes.ToString() + "%";
                iWeight_n.Content = cs.armWeight.ToString();
                iAcc_n.Content = cs.armAcc.ToString();
                iHPR_n.Content = cs.armHPRecovery.ToString();
                iMPR_n.Content = cs.armMPRecovery.ToString();

                cs.armId = SelectGear_cb.SelectedIndex;
            } //Armor
            if (cs.sgn == 8)
            {
                cmd.CommandText = "select * from Helmets where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cs.helDefdp = Convert.ToInt32(dr["DP"]);
                    cs.helDefev = Convert.ToInt32(dr["Evasion"]);
                    cs.helDefhev = Convert.ToInt32(dr["HEvasion"]);
                    cs.helDefdr = Convert.ToInt32(dr["DR"]);
                    cs.helDefhdr = Convert.ToInt32(dr["HDR"]);
                    cs.helDefHP = Convert.ToInt32(dr["MaxHP"]);
                    cs.helSSFDefRes = Convert.ToInt32(dr["SSFREs"]);
                    cs.helKFDefRes = Convert.ToInt32(dr["KFRes"]);
                    cs.helGrapleDefRes = Convert.ToInt32(dr["KBREs"]);
                    cs.helKBDefRes = Convert.ToInt32(dr["GrapleRes"]);
                    cs.helDefWeight = Convert.ToInt32(dr["WeightLimit"]);
                    cs.helEnch = Convert.ToBoolean(dr["Ench"]);
                    cs.helIsBoss = Convert.ToBoolean(dr["IsBossItem"]);
                    cs.helSB = Convert.ToInt32(dr["SetBonus"]);
                    cs.helDefST = Convert.ToInt32(dr["MaxStamina"]);
                    cs.helDefHPRecovery = Convert.ToInt32(dr["HPRecovery"]);
                    cs.helDefLuck = Convert.ToInt32(dr["Luck"]);
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = "Helmets";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                //Helmet_btn.BackgroundImage = Item_image.Image;
                cs.HelmetState();
                if (cs.helEnch == false) Helmet_btn.Content = "";

                if (cs.helEnch == true && SelectGear_cb.SelectedIndex == cs.helId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.helEnchLvl = TempEnchLvl; }
                if (cs.helEnch == true && SelectGear_cb.SelectedIndex != cs.helId) { ItemEnch_cb.SelectedIndex = 0; cs.helEnchLvl = 0; TempEnchLvl = 0; ItemCaph_cb.SelectedIndex = 0; cs.helCaphLvl = 0; TempCaphLvl = 0; }
                else if (cs.helEnch == false) { cs.helEnchLvl = 0; cs.helCaphLvl = 0; }


                iDP_n.Content = cs.heldp.ToString();
                iEvas_n.Content = cs.helev.ToString();
                iHEV_n.Content = cs.helhev.ToString();
                iDR_n.Content = cs.heldr.ToString();
                iHDR_n.Content = cs.helhdr.ToString();
                iHP_n.Content = cs.helHP.ToString();
                iSSFR_n.Content = cs.helSSFRes.ToString() + "%";
                iKBR_n.Content = cs.helKBRes.ToString() + "%";
                iGrapR_n.Content = cs.helGrapleRes.ToString() + "%";
                iKFR_n.Content = cs.helKFRes.ToString() + "%";
                iST_n.Content = cs.helST.ToString();
                iWeight_n.Content = cs.helWeight.ToString();
                iHPR_n.Content = cs.helHPRecovery.ToString();
                iLuck_n.Content = cs.helLuck.ToString();

                cs.helId = SelectGear_cb.SelectedIndex;
            } //Helmet
            if (cs.sgn == 9)
            {
                cmd.CommandText = "select * from Gloves where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cs.glovDefdp = Convert.ToInt32(dr["DP"]);
                    cs.glovDefacc = Convert.ToInt32(dr["Accuracy"]);
                    cs.glovDefev = Convert.ToInt32(dr["Evasion"]);
                    cs.glovDefhev = Convert.ToInt32(dr["HEvasion"]);
                    cs.glovDefdr = Convert.ToInt32(dr["DR"]);
                    cs.glovDefhdr = Convert.ToInt32(dr["HDR"]);
                    cs.glovEnch = Convert.ToBoolean(dr["Ench"]);
                    cs.glovIsBoss = Convert.ToBoolean(dr["IsBossItem"]);
                    cs.glovSB = Convert.ToInt32(dr["SetBonus"]);
                    cs.glovDefAtkSpeed = Convert.ToInt32(dr["AttackSpeed"]);
                    cs.glovDefCastSpeed = Convert.ToInt32(dr["CastSpeed"]);
                    cs.glovDefWeight = Convert.ToInt32(dr["WeightLimit"]);
                    cs.glovDefCrit = Convert.ToInt32(dr["CriticalHit"]);
                    cs.glovDefGrapleRes = Convert.ToInt32(dr["GrapleRes"]);
                    cs.glovDefDamage = Convert.ToInt32(dr["DamageToAll"]);
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = "Gloves";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                //Gloves_btn.BackgroundImage = Item_image.Image;
                cs.GlovesState();
                if (cs.glovEnch == false) Gloves_btn.Content = "";

                if (cs.glovEnch == true && SelectGear_cb.SelectedIndex == cs.glovId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.glovEnchLvl = TempEnchLvl; }
                if (cs.glovEnch == true && SelectGear_cb.SelectedIndex != cs.glovId) { ItemEnch_cb.SelectedIndex = 0; cs.glovEnchLvl = 0; TempEnchLvl = 0; ItemCaph_cb.SelectedIndex = 0; cs.glovCaphLvl = 0; TempCaphLvl = 0; }
                else if (cs.glovEnch == false) { cs.glovEnchLvl = 0; cs.glovCaphLvl = 0; }


                iDP_n.Content = cs.glovdp.ToString();
                iEvas_n.Content = cs.glovev.ToString();
                iHEV_n.Content = cs.glovhev.ToString();
                iDR_n.Content = cs.glovdr.ToString();
                iHDR_n.Content = cs.glovhdr.ToString();
                iAcc_n.Content = cs.glovacc.ToString();
                iGrapR_n.Content = cs.glovGrapleRes.ToString() + "%";
                iAtkSpeed_n.Content = cs.glovAtkSpeed.ToString();
                iCastSpeed_n.Content = cs.glovCastSpeed.ToString();
                iCrit_n.Content = cs.glovCrit.ToString();
                iWeight_n.Content = cs.glovWeight.ToString();
                iEDtA_n.Content = cs.glovDamage.ToString();

                cs.glovId = SelectGear_cb.SelectedIndex;        
            } //Gloves
            if (cs.sgn == 10)
            {
                cmd.CommandText = "select * from Shoes where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cs.shDefdp = Convert.ToInt32(dr["DP"]);
                    cs.shDefev = Convert.ToInt32(dr["Evasion"]);
                    cs.shDefhev = Convert.ToInt32(dr["HEvasion"]);
                    cs.shDefdr = Convert.ToInt32(dr["DR"]);
                    cs.shDefhdr = Convert.ToInt32(dr["HDR"]);
                    cs.shEnch = Convert.ToBoolean(dr["Ench"]);
                    cs.shIsBoss = Convert.ToBoolean(dr["IsBossItem"]);
                    cs.shSB = Convert.ToInt32(dr["SetBonus"]);
                    cs.shDefMvs = Convert.ToInt32(dr["MovmmentSp"]);
                    cs.shDefKBRes = Convert.ToInt32(dr["KBRes"]);
                    cs.shDefMaxST = Convert.ToInt32(dr["MaxStamina"]);
                    cs.shDefWeight = Convert.ToInt32(dr["WeightLimit"]);


                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = "Shoes";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                //Boots_btn.BackgroundImage = Item_image.Image;
                cs.ShoesState();
                if (cs.shEnch == false) Boots_btn.Content = "";
                if (cs.shEnch == true && SelectGear_cb.SelectedIndex == cs.shId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.shEnchLvl = TempEnchLvl; }
                if (cs.shEnch == true && SelectGear_cb.SelectedIndex != cs.shId) { ItemEnch_cb.SelectedIndex = 0; cs.shEnchLvl = 0; TempEnchLvl = 0; ItemCaph_cb.SelectedIndex = 0; cs.shCaphLvl = 0; TempCaphLvl = 0; }
                else if (cs.shEnch == false) { cs.shEnchLvl = 0; cs.shCaphLvl = 0; }


                iDP_n.Content = cs.shdp.ToString();
                iEvas_n.Content = cs.shev.ToString();
                iHEV_n.Content = cs.shhev.ToString();
                iDR_n.Content = cs.shdr.ToString();
                iHDR_n.Content = cs.shhdr.ToString();
                iKBR_n.Content = cs.shKBRes.ToString();
                iMVS_n.Content = cs.shMvs.ToString();
                iST_n.Content = cs.shMaxST.ToString();
                iWeight_n.Content = cs.shWeight.ToString();

                cs.shId = SelectGear_cb.SelectedIndex;
            } //Shoes
            if (cs.sgn == 11)
            {
                cmd.CommandText = "select * from [" + sclass + " Awakening Weapons] where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (sclass == "Shai")
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.awkDefAPhigh = Convert.ToInt32(dr["APhigh"]);
                        cs.awkDefAPlow = Convert.ToInt32(dr["APlow"]);
                        cs.awkDefAccuracy = 0;
                        cs.awkDefDamageHumans = 0;
                        cs.awkCheckHd = false;
                        cs.awkDefDamageAll = 0;
                        cs.awkCheckAd = false;
                        cs.awkDefAPagainst = 0;
                        cs.awkCheckAg = false;
                        cs.awkEnch = Convert.ToBoolean(dr["Ench"]);
                        cs.awkDefAllEvasion = Convert.ToInt32(dr["AllEvasion"]);
                        cs.awkDefDPReduction = Convert.ToInt32(dr["DPReduction"]);
                        cs.awkDefMvsSpeedRed = Convert.ToInt32(dr["MvsSpeedRed"]);
                        cs.awkDefSpeedIncrease = Convert.ToInt32(dr["SpeedIncrease"]);
                    }
                }

                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.awkDefAPhigh = Convert.ToInt32(dr["APhigh"]);
                        cs.awkDefAPlow = Convert.ToInt32(dr["APlow"]);
                        cs.awkDefAccuracy = Convert.ToInt32(dr["Accuracy"]);
                        cs.awkDefDamageHumans = Convert.ToInt32(dr["HumanDamage"]);
                        cs.awkCheckHd = Convert.ToBoolean(dr["CheckHd"]);
                        cs.awkDefDamageAll = Convert.ToInt32(dr["DamageAllSpecies"]);
                        cs.awkCheckAd = Convert.ToBoolean(dr["CheckAd"]);
                        cs.awkDefAPagainst = Convert.ToInt32(dr["ApAgainst"]);
                        cs.awkCheckAg = Convert.ToBoolean(dr["CheckAg"]);
                        cs.awkEnch = Convert.ToBoolean(dr["Ench"]);
                        cs.awkDefAllEvasion = 0;
                        cs.awkDefDPReduction = 0;
                        cs.awkDefMvsSpeedRed = 0;
                        cs.awkDefSpeedIncrease = 0;
                    }
                }
                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = "" + sclass + " Awakening Weapons";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                //AW_btn.BackgroundImage = Item_image.Image;
                cs.AwakeningState(sclass);
                if (cs.awkEnch == false) AW_btn.Content = "";

                if (cs.awkEnch == true && SelectGear_cb.SelectedIndex == cs.awkId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.awkEnchLvl = TempEnchLvl; }
                if (cs.awkEnch == true && SelectGear_cb.SelectedIndex != cs.awkId) { ItemEnch_cb.SelectedIndex = 0; cs.awkEnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.awkEnch == false) { cs.awkEnchLvl = 0; }

                iAP_n.Content = cs.awkAPlow.ToString() + '~' + cs.awkAPhigh.ToString();
                iAcc_n.Content = cs.awkAccuracy.ToString();
                iEDH_n.Content = cs.awkDamageHumans.ToString();
                iEDtA_n.Content = cs.awkDamageAll.ToString();
                iEAPa_n.Content = cs.awkAPagainst.ToString();

                cs.awkId = SelectGear_cb.SelectedIndex;
                LoadItemEnch_cb();

            } //Awakening Weapon 
            if (cs.sgn == 12)
            {
                cmd.CommandText = "select * from [" + chWeapon + " Main Weapon] where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);


                foreach (DataRow dr in dt.Rows)
                {

                    cs.mwDefAPhigh = Convert.ToInt32(dr["APhigh"]);
                    cs.mwDefAPlow = Convert.ToInt32(dr["APlow"]);
                    cs.mwDefAccuracy = Convert.ToInt32(dr["Accuracy"]);
                    cs.mwDefDamageHumans = Convert.ToInt32(dr["DamHum"]);
                    cs.mwDefDamageAll = Convert.ToInt32(dr["DamAll"]);
                    cs.mwDefAPagainst = Convert.ToInt32(dr["ApAgainst"]);
                    cs.mwDefDamDemi = Convert.ToInt32(dr["DamDemi"]);
                    cs.mwDefAtkSpeed = Convert.ToInt32(dr["AtkSpeed"]);
                    cs.mwDefCastSpeed = Convert.ToInt32(dr["CastSpeed"]);
                    cs.mwDefCrit = Convert.ToInt32(dr["Crit"]);
                    cs.mwDefHidenAP = Convert.ToInt32(dr["HidenAP"]);
                    cs.mwDefIgnore = Convert.ToInt32(dr["IgnoreRes"]);
                    cs.mwDefRecoveryChance = Convert.ToInt32(dr["ChanceRecovery"]);
                    cs.mwEnch = Convert.ToBoolean(dr["Ench"]);
                    cs.mwSB = Convert.ToInt32(dr["SetBonus"]);
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = "" + chWeapon + " Main Weapon";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                //MW_btn.BackgroundImage = Item_image.Image;
                cs.MainWeaponState(chWeapon);
                if (cs.mwEnch == false) MW_btn.Content = "";

                if (cs.mwEnch == true && SelectGear_cb.SelectedIndex == cs.mwId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.mwEnchLvl = TempEnchLvl; }
                if (cs.mwEnch == true && SelectGear_cb.SelectedIndex != cs.mwId) { ItemEnch_cb.SelectedIndex = 0; cs.mwEnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.mwEnch == false) { cs.mwEnchLvl = 0; }

                iAP_n.Content = cs.mwAPlow.ToString() + '~' + cs.mwAPhigh.ToString();
                iAcc_n.Content = cs.mwAccuracy.ToString();
                iEDH_n.Content = cs.mwDamageHumans.ToString();
                iEDtA_n.Content = cs.mwDamageAll.ToString();
                iEAPa_n.Content = cs.mwAPagainst.ToString();
                iADtDemiH_n.Content = cs.mwDamDemi.ToString();
                iAtkSpeed_n.Content = cs.mwAtkSpeed.ToString();
                iCastSpeed_n.Content = cs.mwCastSpeed.ToString();
                iCrit_n.Content = cs.mwCrit.ToString();
                iHPRecoveryChance_n.Content = cs.mwRecoveryChance.ToString();
                iIgnoreResistance_n.Content = cs.mwIgnore.ToString();



                cs.mwId = SelectGear_cb.SelectedIndex;
                LoadItemEnch_cb();

            } //Main Weapon 
            if (cs.sgn == 13)
            {
                cmd.CommandText = "select * from [" + chSubWeapon + " Sub-Weapons] where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cs.swDefAPhigh = Convert.ToInt32(dr["APhigh"]);
                    cs.swDefAPlow = Convert.ToInt32(dr["APlow"]);
                    cs.swDefAccuracy = Convert.ToInt32(dr["Accuracy"]);
                    cs.swDefAPagainst = Convert.ToInt32(dr["ApAgainst"]);
                    cs.swDefHidenAP = Convert.ToInt32(dr["HidenAP"]);
                    cs.swDefIgnore = Convert.ToInt32(dr["IgnoreRes"]);
                    cs.swDefDP = Convert.ToInt32(dr["DP"]);
                    cs.swDefDR = Convert.ToInt32(dr["DR"]);
                    cs.swDefEvasion = Convert.ToInt32(dr["Evasion"]);
                    cs.swDefHEvasion = Convert.ToInt32(dr["HEvasion"]);
                    cs.swDefMaxHP = Convert.ToInt32(dr["MaxHP"]);
                    cs.swDefMaxMP = Convert.ToInt32(dr["MaxMP"]);
                    cs.swDefMaxST = Convert.ToInt32(dr["MaxST"]);
                    cs.swDefSpecialAttackEv = Convert.ToInt32(dr["SpecialAttackEv"]);
                    cs.swDefSpecialAttackDam = Convert.ToInt32(dr["SpecialAttackDam"]);
                    cs.swDefAllRes = Convert.ToInt32(dr["AllRes"]);
                    cs.swEnch = Convert.ToBoolean(dr["Ench"]);
                    cs.swSB = Convert.ToInt32(dr["SetBonus"]);
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = "" + chSubWeapon + " Sub-Weapons";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                //SW_btn.BackgroundImage = Item_image.Image;
                cs.SubWeaponState(chSubWeapon);
                if (cs.swEnch == false) SW_btn.Content = "";

                if (cs.swEnch == true && SelectGear_cb.SelectedIndex == cs.swId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.swEnchLvl = TempEnchLvl; }
                if (cs.swEnch == true && SelectGear_cb.SelectedIndex != cs.swId) { ItemEnch_cb.SelectedIndex = 0; cs.swEnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.swEnch == false) { cs.swEnchLvl = 0; }

                iAP_n.Content = cs.swAPlow.ToString() + '~' + cs.swAPhigh.ToString();
                iAcc_n.Content = cs.swAccuracy.ToString();
                iEAPa_n.Content = cs.swAPagainst.ToString();
                iIgnoreResistance_n.Content = cs.swIgnore.ToString();
                iDP_n.Content = cs.swDP.ToString();
                iEvas_n.Content = cs.swEvasion.ToString();
                iHEV_n.Content = cs.swHEvasion.ToString();
                iDR_n.Content = cs.swDR.ToString();
                iHP_n.Content = cs.swMaxHP.ToString();
                iMP_n.Content = cs.swMaxMP.ToString();
                iST_n.Content = cs.swMaxST.ToString();
                iRes_n.Content = cs.swAllRes.ToString();
                iST_n.Content = cs.swMaxST.ToString();
                iST_n.Content = cs.swMaxST.ToString();
                iHAP_n.Content = cs.swHidenAP.ToString();
                iSpecialAttackED_n.Content = cs.swSpecialAttackDam.ToString();
                iSpecialAttackEvRate_n.Content = cs.swSpecialAttackEv.ToString();


                cs.swId = SelectGear_cb.SelectedIndex;
                LoadItemEnch_cb();

            } //Sub-Weapons 
            if (cs.sgn == 14)
            {
                cmd.CommandText = "select * from [Alchemy Stones] where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cs.asDefAPhigh = Convert.ToInt32(dr["APhigh"]);
                    cs.asDefAPlow = Convert.ToInt32(dr["APlow"]);
                    cs.asDefAccuracy = Convert.ToInt32(dr["Accuracy"]);
                    cs.asDefHidenAP = Convert.ToInt32(dr["HidenAP"]);
                    cs.asDefIgnore = Convert.ToInt32(dr["IgnoreRes"]);
                    cs.asDefDR = Convert.ToInt32(dr["DR"]);
                    cs.asDefEvasion = Convert.ToInt32(dr["Evasion"]);
                    cs.asDefMaxHP = Convert.ToInt32(dr["MaxHP"]);
                    cs.asDefAllRes = Convert.ToInt32(dr["AllRes"]);
                    cs.asEnch = Convert.ToBoolean(dr["Ench"]);
                    cs.asDefAtkSpeed = Convert.ToInt32(dr["AtkSpeed"]);
                    cs.asDefCastSpeed = Convert.ToInt32(dr["CastSpeed"]);
                    cs.asDefWeightLimit = Convert.ToInt32(dr["WeightLimit"]);
                    cs.asDefGathFish = Convert.ToInt32(dr["GathFish"]);
                    cs.asDefGathDropRate = Convert.ToInt32(dr["GathDrop"]);
                    cs.asDefAlchCookTime = Convert.ToDouble(dr["AlchCockTime"]);

                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = "Alchemy Stones";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                //AS_btn.BackgroundImage = Item_image.Image;
                cs.AlchemyStoneState();
                if (cs.asEnch == false) AS_btn.Content = "";

                iAP_n.Content = cs.asAPlow.ToString() + '~' + cs.asAPhigh.ToString();
                iAcc_n.Content = cs.asAccuracy.ToString();
                iIgnoreResistance_n.Content = cs.asIgnore.ToString();
                iEvas_n.Content = cs.asEvasion.ToString();
                iDR_n.Content = cs.asDR.ToString();
                iHP_n.Content = cs.asMaxHP.ToString();
                iRes_n.Content = cs.asAllRes.ToString() + "%";
                iHAP_n.Content = cs.asHidenAP.ToString();
                iWeight_n.Content = cs.asWeightLimit.ToString();
                iCastSpeedRate_n.Content = cs.asCastSpeed.ToString() + "%";
                iAtkSpeedRate_n.Content = cs.asAtkSpeed.ToString() + "%";
                iAlchCookTime_n.Content = cs.asAlchCookTime.ToString();
                iProcessingRate_n.Content = cs.asProcRate.ToString() + "%";
                iGathering_n.Content = cs.asGathFish.ToString();
                iFishing_n.Content = cs.asGathFish.ToString();
                iGathDropRate_n.Content = cs.asGathDropRate.ToString() + "%";



                cs.asId = SelectGear_cb.SelectedIndex;
                LoadItemEnch_cb();

            } //Alchemy Stones
            //SetBonus
            cs.BossSetBonusCheck();
            cs.AccSetBonusCheck();
            cs.WeaponSetBonusCheck();
            cs.BossSetBonus();
            cs.AccSetBonus();
            cs.WeaponSetBonus();
            FillCharacterState();
        }

        private void LoadItemEnch_cb()
        {
            if (cs.sgn == 1 & cs.beltEnch == true | cs.sgn == 2 & cs.neckEnch == true | cs.sgn == 3 & cs.ring1Ench == true |
                cs.sgn == 4 & cs.ring2Ench == true | cs.sgn == 5 & cs.ear1Ench == true | cs.sgn == 6 & cs.ear2Ench == true)
            {
                ItemEnch_cb.SelectionChanged -= ItemEnch_cb_SelectionChanged;
                ItemEnch_cb.Visibility = Visibility.Visible; Ench_lbl.Visibility = Visibility.Visible;
                string[] EnchAccessories = { "0", "I", "II", "III", "IV", "V" };
                ItemEnch_cb.ItemsSource = EnchAccessories;
                ItemEnch_cb.SelectionChanged += ItemEnch_cb_SelectionChanged;
                if (cs.sgn == 1) ItemEnch_cb.SelectedIndex = cs.beltEnchLvl;
                else if (cs.sgn == 2) ItemEnch_cb.SelectedIndex = cs.neckEnchLvl;
                else if (cs.sgn == 3) ItemEnch_cb.SelectedIndex = cs.ring1EnchLvl;
                else if (cs.sgn == 4) ItemEnch_cb.SelectedIndex = cs.ring2EnchLvl;
                else if (cs.sgn == 5) ItemEnch_cb.SelectedIndex = cs.ear1EnchLvl;
                else if (cs.sgn == 6) ItemEnch_cb.SelectedIndex = cs.ear2EnchLvl;
            } //For accesories



            else if (cs.sgn == 7 & cs.armEnch == true | cs.sgn == 8 & cs.helEnch == true | cs.sgn == 9 & cs.glovEnch == true | cs.sgn == 10 & cs.shEnch == true | cs.sgn == 11 & cs.awkEnch == true & cs.awkId != 1 | cs.sgn == 12 & cs.mwEnch == true & cs.mwId != 3 | cs.sgn == 13 & cs.swEnch == true & cs.swId != 7 & cs.swId != 38)
            {
                ItemEnch_cb.SelectionChanged -= ItemEnch_cb_SelectionChanged;
                ItemEnch_cb.Visibility = Visibility.Visible; Ench_lbl.Visibility = Visibility.Visible;
                string[] EnchArmor = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "I", "II", "III", "IV", "V" };
                ItemEnch_cb.ItemsSource = EnchArmor;
                ItemEnch_cb.SelectionChanged += ItemEnch_cb_SelectionChanged;
                if (cs.sgn == 7) ItemEnch_cb.SelectedIndex = cs.armEnchLvl;
                if (cs.sgn == 8) ItemEnch_cb.SelectedIndex = cs.helEnchLvl;
                if (cs.sgn == 9) ItemEnch_cb.SelectedIndex = cs.glovEnchLvl;
                if (cs.sgn == 10) ItemEnch_cb.SelectedIndex = cs.shEnchLvl;
                if (cs.sgn == 11) ItemEnch_cb.SelectedIndex = cs.awkEnchLvl;
                if (cs.sgn == 12) ItemEnch_cb.SelectedIndex = cs.mwEnchLvl;
                if (cs.sgn == 13) ItemEnch_cb.SelectedIndex = cs.swEnchLvl;

            } //For armor and weapons

            else if (cs.sgn == 11 & cs.awkId == 1 & cs.awkEnch == true | cs.sgn == 12 & cs.mwId == 3 & cs.mwEnch == true | cs.sgn == 13 & cs.swId == 7 | cs.sgn == 13 & cs.swId == 38)
            {
                ItemEnch_cb.SelectionChanged -= ItemEnch_cb_SelectionChanged;
                ItemEnch_cb.Visibility = Visibility.Visible; Ench_lbl.Visibility = Visibility.Visible;
                string[] EnchArmor = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "I", "II", "III", "IV" };
                ItemEnch_cb.ItemsSource = EnchArmor;
                ItemEnch_cb.SelectionChanged += ItemEnch_cb_SelectionChanged;
                if (cs.sgn == 11) ItemEnch_cb.SelectedIndex = cs.awkEnchLvl;
                if (cs.sgn == 12) ItemEnch_cb.SelectedIndex = cs.mwEnchLvl;
                if (cs.sgn == 13) ItemEnch_cb.SelectedIndex = cs.swEnchLvl;

            }
            else { ItemEnch_cb.Visibility = Visibility.Hidden; Ench_lbl.Visibility = Visibility.Hidden; }
        }

        private void LoadItemCaph_cb()
        {
            if (cs.mwEnchLvl >= 18 & cs.mwId != 0 & cs.mwId != 3 & cs.sgn == 12 & cs.mwEnch == true | cs.awkEnchLvl >= 18 & cs.awkId != 1 & cs.sgn == 11 & cs.awkEnch == true | cs.swEnchLvl >= 18 & cs.swId != 7 & cs.sgn == 13 & cs.swEnch == true | cs.armEnchLvl >= 18 & cs.sgn == 7 & cs.armEnch == true | cs.helEnchLvl >= 18 & cs.sgn == 8 & cs.helEnch == true | cs.glovEnchLvl >= 18 & cs.sgn == 9 & cs.glovEnch == true | cs.shEnchLvl >= 18 & cs.sgn == 10 & cs.shEnch == true)
            {
                ItemCaph_cb.SelectionChanged -= ItemCaph_cb_SelectionChanged;
                ItemCaph_cb.Visibility = Visibility.Visible;
                Caph_lbl.Visibility = Visibility.Visible;
                string[] CaphArmor = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
                ItemCaph_cb.ItemsSource = CaphArmor;
                ItemCaph_cb.SelectionChanged += ItemCaph_cb_SelectionChanged;
            }
            else
            {
                ItemCaph_cb.Visibility = Visibility.Visible;
                Caph_lbl.Visibility = Visibility.Visible;
                string[] CaphArmor = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
                ItemCaph_cb.ItemsSource = CaphArmor;
            }
            if (cs.sgn == 7) ItemCaph_cb.SelectedIndex = cs.armCaphLvl;
            if (cs.sgn == 8) ItemCaph_cb.SelectedIndex = cs.helCaphLvl;
            if (cs.sgn == 9) ItemCaph_cb.SelectedIndex = cs.glovCaphLvl;
            if (cs.sgn == 10) ItemCaph_cb.SelectedIndex = cs.shCaphLvl;
            if (cs.sgn == 11) ItemCaph_cb.SelectedIndex = cs.awkCaphLvl;
            if (cs.sgn == 12) ItemCaph_cb.SelectedIndex = cs.mwCaphLvl;
            if (cs.sgn == 13) ItemCaph_cb.SelectedIndex = cs.swCaphLvl;
        }

        private void ItemEnch_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemStatClear();
            if (cs.sgn == 1)
            {
                cs.beltEnchLvl = ItemEnch_cb.SelectedIndex;
                cs.BeltState();

                iAP_n.Content = cs.beltap.ToString();
                iDP_n.Content = cs.beltdp.ToString();
                iEvas_n.Content = cs.beltev.ToString();
                iAcc_n.Content = cs.beltacc.ToString();
                iRes_n.Content = cs.beltResis.ToString();
                iDR_n.Content = cs.beltDR.ToString();
                iHP_n.Content = cs.beltHP.ToString();
                iWeight_n.Content = cs.beltWeight.ToString();
                iSpiritRage_n.Content = Convert.ToString(cs.beltSpiritRage) + "%";
                iEAPa_n.Content = cs.beltAPagaingst.ToString();

                if (ItemEnch_cb.SelectedIndex == 0) { Belt_btn.Content = ""; }
                else if (cs.beltEnch == false) Belt_btn.Content = "";
                else { Belt_btn.Content = ItemEnch_cb.Text; }

                FillCharacterState();

            } //Belt

            else if (cs.sgn == 2)
            {
                cs.neckEnchLvl = ItemEnch_cb.SelectedIndex;
                cs.NeckState();

                iAP_n.Content = cs.neckap.ToString();
                iDP_n.Content = cs.neckdp.ToString();
                iEvas_n.Content = cs.neckev.ToString();
                iAcc_n.Content = cs.neckacc.ToString();
                iRes_n.Content = cs.neckAllRes.ToString() + "%";
                iDR_n.Content = cs.neckDR.ToString();
                iSSFR_n.Content = cs.neckSSF.ToString() + "%";
                iKBR_n.Content = cs.neckKB.ToString() + "%";
                iGrapR_n.Content = cs.neckG.ToString() + "%";
                iKFR_n.Content = cs.neckKF.ToString() + "%";
                iHP_n.Content = cs.neckHP.ToString();
                iSpiritRage_n.Content = Convert.ToString(cs.neckSpiritRage) + "%";
                iEAPa_n.Content = cs.neckAPagaingst.ToString();
                iExtraDamKama_n.Content = cs.neckKamaDamage.ToString();
                iEDtoBack_n.Content = cs.neckBackDamage.ToString() + "%";

                if (ItemEnch_cb.SelectedIndex == 0) { Necklace_btn.Content = ""; }
                else { Necklace_btn.Content = ItemEnch_cb.Text; }

                FillCharacterState();

            } //Neck

            else if (cs.sgn == 3)
            {
                cs.ring1EnchLvl = ItemEnch_cb.SelectedIndex;
                cs.Ring1State();

                iAP_n.Content = cs.ring1ap.ToString();
                iDP_n.Content = cs.ring1dp.ToString();
                iEvas_n.Content = cs.ring1ev.ToString();
                iAcc_n.Content = cs.ring1acc.ToString();
                iDR_n.Content = cs.ring1DR.ToString();
                iHP_n.Content = cs.ring1HP.ToString();
                iMP_n.Content = cs.ring1MP.ToString();
                iST_n.Content = cs.ring1ST.ToString();
                iEDH_n.Content = cs.ring1DamageHumans.ToString();
                iADtDemiH_n.Content = cs.ring1DamageDemihumans.ToString();
                iEDtAExcHumanAndDemi_n.Content = cs.ring1DamageAllExcept.ToString();
                iEAPa_n.Content = cs.ring1APagaingst.ToString();
                iBidding_n.Content = Convert.ToString(cs.ring1Bidding) + "%";
                iSpiritRage_n.Content = Convert.ToString(cs.ring1SpiritRage) + "%";

                if (ItemEnch_cb.SelectedIndex == 0) { Ring1_btn.Content = ""; }
                else { Ring1_btn.Content = ItemEnch_cb.Text; }

                FillCharacterState();
            } // Ring1

            else if (cs.sgn == 4)
            {
                cs.ring2EnchLvl = ItemEnch_cb.SelectedIndex;
                cs.Ring2State();

                iAP_n.Content = cs.ring2ap.ToString();
                iDP_n.Content = cs.ring2dp.ToString();
                iEvas_n.Content = cs.ring2ev.ToString();
                iAcc_n.Content = cs.ring2acc.ToString();
                iDR_n.Content = cs.ring2DR.ToString();
                iHP_n.Content = cs.ring2HP.ToString();
                iMP_n.Content = cs.ring2MP.ToString();
                iST_n.Content = cs.ring2ST.ToString();
                iEDH_n.Content = cs.ring2DamageHumans.ToString();
                iADtDemiH_n.Content = cs.ring2DamageDemihumans.ToString();
                iEDtAExcHumanAndDemi_n.Content = cs.ring2DamageAllExcept.ToString();
                iEAPa_n.Content = cs.ring2APagaingst.ToString();
                iBidding_n.Content = Convert.ToString(cs.ring2Bidding) + "%";
                iSpiritRage_n.Content = Convert.ToString(cs.ring2SpiritRage) + "%";

                if (ItemEnch_cb.SelectedIndex == 0) { Ring2_btn.Content = ""; }
                else { Ring2_btn.Content = ItemEnch_cb.Text; }

                FillCharacterState();
            } //Ring2

            else if (cs.sgn == 5)
            {
                cs.ear1EnchLvl = ItemEnch_cb.SelectedIndex;
                cs.Earring1State();

                iAP_n.Content = cs.ear1ap.ToString();
                iDP_n.Content = cs.ear1dp.ToString();
                iEvas_n.Content = cs.ear1ev.ToString();
                iAcc_n.Content = cs.ear1acc.ToString();
                iDR_n.Content = cs.ear1DR.ToString();
                iHP_n.Content = cs.ear1HP.ToString();
                iMP_n.Content = cs.ear1MP.ToString();
                iST_n.Content = cs.ear1ST.ToString();
                iSpiritRage_n.Content = Convert.ToString(cs.ear1SpiritRage) + "%";
                iEAPa_n.Content = cs.ear1APagaingst.ToString();
                iExtraDamKama_n.Content = cs.ear1KamaDamage.ToString();

                if (ItemEnch_cb.SelectedIndex == 0) { Earring1_btn.Content = ""; }
                else { Earring1_btn.Content = ItemEnch_cb.Text; }

                FillCharacterState();
            } //Earring 1

            else if (cs.sgn == 6)
            {
                cs.ear2EnchLvl = ItemEnch_cb.SelectedIndex;
                cs.Earring2State();

                iAP_n.Content = cs.ear2ap.ToString();
                iDP_n.Content = cs.ear2dp.ToString();
                iEvas_n.Content = cs.ear2ev.ToString();
                iAcc_n.Content = cs.ear2acc.ToString();
                iDR_n.Content = cs.ear2DR.ToString();
                iHP_n.Content = cs.ear2HP.ToString();
                iMP_n.Content = cs.ear2MP.ToString();
                iST_n.Content = cs.ear2ST.ToString();
                iSpiritRage_n.Content = Convert.ToString(cs.ear2SpiritRage) + "%";
                iEAPa_n.Content = cs.ear2APagaingst.ToString();
                iExtraDamKama_n.Content = cs.ear2KamaDamage.ToString();

                if (ItemEnch_cb.SelectedIndex == 0) { Earring2_btn.Content = ""; }
                else { Earring2_btn.Content = ItemEnch_cb.Text; }

                FillCharacterState();
            } //Earring 2

            else if (cs.sgn == 7)
            {
                LoadItemCaph_cb();
                if (cs.armEnchLvl >= 18) { TempCaphLvl = ItemCaph_cb.SelectedIndex; cs.armCaphLvl = TempCaphLvl; }
                if (cs.armEnchLvl >= 18 & ItemEnch_cb.SelectedIndex != cs.armEnchLvl) { ItemCaph_cb.SelectedIndex = 0; cs.armCaphLvl = 0; TempCaphLvl = 0; }
                else if (cs.armEnchLvl < 18) { cs.armCaphLvl = 0; }

                cs.armEnchLvl = ItemEnch_cb.SelectedIndex;
                cs.ArmorState();

                iDP_n.Content = cs.armdp.ToString();
                iEvas_n.Content = cs.armev.ToString();
                iHEV_n.Content = cs.armhev.ToString();
                iDR_n.Content = cs.armdr.ToString();
                iHDR_n.Content = cs.armhdr.ToString();
                iHP_n.Content = cs.armHP.ToString();
                iMP_n.Content = cs.armMP.ToString();
                iSSFR_n.Content = cs.armSSFRes.ToString() + "%";
                iWeight_n.Content = cs.armWeight.ToString();
                iAcc_n.Content = cs.armAcc.ToString();
                iHPR_n.Content = cs.armHPRecovery.ToString();
                iMPR_n.Content = cs.armMPRecovery.ToString();

                if (ItemEnch_cb.SelectedIndex == 0) { Armour_btn.Content = ""; }
                else if (ItemEnch_cb.SelectedIndex >= 1 & ItemEnch_cb.SelectedIndex <= 15) { Armour_btn.Content = "+" + ItemEnch_cb.Text; }
                else Armour_btn.Content = ItemEnch_cb.Text;

                FillCharacterState();
            } // Armor

            else if (cs.sgn == 8)
            {
                LoadItemCaph_cb();
                if (cs.helEnchLvl >= 18) { TempCaphLvl = ItemCaph_cb.SelectedIndex; cs.helCaphLvl = TempCaphLvl; }
                if (cs.helEnchLvl >= 18 & ItemEnch_cb.SelectedIndex != cs.helEnchLvl) { ItemCaph_cb.SelectedIndex = 0; cs.helCaphLvl = 0; TempCaphLvl = 0; }
                else if (cs.helEnchLvl < 18) { cs.helCaphLvl = 0; }

                cs.helEnchLvl = ItemEnch_cb.SelectedIndex;
                cs.HelmetState();

                iDP_n.Content = cs.heldp.ToString();
                iEvas_n.Content = cs.helev.ToString();
                iHEV_n.Content = cs.helhev.ToString();
                iDR_n.Content = cs.heldr.ToString();
                iHDR_n.Content = cs.helhdr.ToString();
                iHP_n.Content = cs.helHP.ToString();
                iSSFR_n.Content = cs.helSSFRes.ToString() + "%";
                iKBR_n.Content = cs.helKBRes.ToString() + "%";
                iGrapR_n.Content = cs.helGrapleRes.ToString() + "%";
                iKFR_n.Content = cs.helKFRes.ToString() + "%";
                iST_n.Content = cs.helWeight.ToString();
                iHPR_n.Content = cs.helHPRecovery.ToString();
                iLuck_n.Content = cs.helLuck.ToString();

                if (ItemEnch_cb.SelectedIndex == 0) { Helmet_btn.Content = ""; }
                else if (ItemEnch_cb.SelectedIndex >= 1 & ItemEnch_cb.SelectedIndex <= 15) { Helmet_btn.Content = "+" + ItemEnch_cb.Text; }
                else Helmet_btn.Content = ItemEnch_cb.Text;
                FillCharacterState();
            } // Helmet

            else if (cs.sgn == 9)
            {
                LoadItemCaph_cb();
                if (cs.glovEnchLvl >= 18) { TempCaphLvl = ItemCaph_cb.SelectedIndex; cs.glovCaphLvl = TempCaphLvl; }
                if (cs.glovEnchLvl >= 18 & ItemEnch_cb.SelectedIndex != cs.glovEnchLvl) { ItemCaph_cb.SelectedIndex = 0; cs.glovCaphLvl = 0; TempCaphLvl = 0; }
                else if (cs.glovEnchLvl < 18) { cs.glovCaphLvl = 0; }

                cs.glovEnchLvl = ItemEnch_cb.SelectedIndex;
                cs.GlovesState();

                iDP_n.Content = cs.glovdp.ToString();
                iAcc_n.Content = cs.glovacc.ToString();
                iEvas_n.Content = cs.glovev.ToString();
                iHEV_n.Content = cs.glovhev.ToString();
                iDR_n.Content = cs.glovdr.ToString();
                iHDR_n.Content = cs.glovhdr.ToString();
                iGrapR_n.Content = cs.glovGrapleRes.ToString() + "%";
                iAtkSpeed_n.Content = cs.glovAtkSpeed.ToString();
                iCastSpeed_n.Content = cs.glovCastSpeed.ToString();
                iCrit_n.Content = cs.glovCrit.ToString();
                iWeight_n.Content = cs.glovWeight.ToString();
                iEDtA_n.Content = cs.glovDamage.ToString();

                if (ItemEnch_cb.SelectedIndex == 0) { Gloves_btn.Content = ""; }
                else if (ItemEnch_cb.SelectedIndex >= 1 & ItemEnch_cb.SelectedIndex <= 15) { Gloves_btn.Content = "+" + ItemEnch_cb.Text; }
                else Gloves_btn.Content = ItemEnch_cb.Text;

                FillCharacterState();
            } //Gloves

            else if (cs.sgn == 10)
            {
                LoadItemCaph_cb();
                if (cs.shEnchLvl >= 18) { TempCaphLvl = ItemCaph_cb.SelectedIndex; cs.shCaphLvl = TempCaphLvl; }
                if (cs.shEnchLvl >= 18 & ItemEnch_cb.SelectedIndex != cs.shEnchLvl) { ItemCaph_cb.SelectedIndex = 0; cs.shCaphLvl = 0; TempCaphLvl = 0; }
                else if (cs.shEnchLvl < 18) { cs.shCaphLvl = 0; }

                cs.shEnchLvl = ItemEnch_cb.SelectedIndex;
                cs.ShoesState();

                iDP_n.Content = cs.shdp.ToString();
                iEvas_n.Content = cs.shev.ToString();
                iHEV_n.Content = cs.shhev.ToString();
                iDR_n.Content = cs.shdr.ToString();
                iHDR_n.Content = cs.shhdr.ToString();
                iKBR_n.Content = cs.shKBRes.ToString();
                iMVS_n.Content = cs.shMvs.ToString();
                iST_n.Content = cs.shMaxST.ToString();
                iWeight_n.Content = cs.shWeight.ToString();

                if (ItemEnch_cb.SelectedIndex == 0) { Boots_btn.Content = ""; }
                else if (ItemEnch_cb.SelectedIndex >= 1 & ItemEnch_cb.SelectedIndex <= 15) { Boots_btn.Content = "+" + ItemEnch_cb.Text; }
                else Boots_btn.Content = ItemEnch_cb.Text;

                FillCharacterState();
            } //Shoes

            else if (cs.sgn == 11)
            {
                LoadItemCaph_cb();
                if (cs.awkEnchLvl >= 18) { TempCaphLvl = ItemCaph_cb.SelectedIndex; cs.awkCaphLvl = TempCaphLvl; }
                if (cs.awkEnchLvl >= 18 & ItemEnch_cb.SelectedIndex != cs.awkEnchLvl) { ItemCaph_cb.SelectedIndex = 0; cs.awkCaphLvl = 0; TempCaphLvl = 0; }
                else if (cs.awkEnchLvl < 18) { cs.awkCaphLvl = 0; }

                cs.awkEnchLvl = ItemEnch_cb.SelectedIndex;
                cs.AwakeningState(sclass);

                iAP_n.Content = cs.awkAPlow.ToString() + '~' + cs.awkAPhigh.ToString();
                iAcc_n.Content = cs.awkAccuracy.ToString();
                iEDH_n.Content = cs.awkDamageHumans.ToString();
                iEDtA_n.Content = cs.awkDamageAll.ToString();
                iEAPa_n.Content = cs.awkAPagainst.ToString();

                if (ItemEnch_cb.SelectedIndex == 0) { AW_btn.Content = ""; }
                else if (ItemEnch_cb.SelectedIndex >= 1 & ItemEnch_cb.SelectedIndex <= 15) { AW_btn.Content = "+" + ItemEnch_cb.Text; }
                else AW_btn.Content = ItemEnch_cb.Text;

                FillCharacterState();
            } //Awakening Weapons

            else if (cs.sgn == 12)
            {
                LoadItemCaph_cb();
                if (cs.mwEnchLvl >= 18) { TempCaphLvl = ItemCaph_cb.SelectedIndex; cs.mwCaphLvl = TempCaphLvl; }
                if (cs.mwEnchLvl >= 18 & ItemEnch_cb.SelectedIndex != cs.mwEnchLvl) { ItemCaph_cb.SelectedIndex = 0; cs.mwCaphLvl = 0; TempCaphLvl = 0; }
                else if (cs.mwEnchLvl < 18) { cs.mwCaphLvl = 0; }

                cs.mwEnchLvl = ItemEnch_cb.SelectedIndex;
                cs.MainWeaponState(chWeapon);

                iAP_n.Content = cs.mwAPlow.ToString() + '~' + cs.mwAPhigh.ToString();
                iAcc_n.Content = cs.mwAccuracy.ToString();
                iEDH_n.Content = cs.mwDamageHumans.ToString();
                iEDtA_n.Content = cs.mwDamageAll.ToString();
                iEAPa_n.Content = cs.mwAPagainst.ToString();
                iADtDemiH_n.Content = cs.mwDamDemi.ToString();
                iAtkSpeed_n.Content = cs.mwAtkSpeed.ToString();
                iCastSpeed_n.Content = cs.mwCastSpeed.ToString();
                iCrit_n.Content = cs.mwCrit.ToString();
                iHPRecoveryChance_n.Content = cs.mwRecoveryChance.ToString();
                iIgnoreResistance_n.Content = cs.mwIgnore.ToString();

                if (ItemEnch_cb.SelectedIndex == 0) { MW_btn.Content = ""; }
                else if (ItemEnch_cb.SelectedIndex >= 1 & ItemEnch_cb.SelectedIndex <= 15) { MW_btn.Content = "+" + ItemEnch_cb.Text; }
                else MW_btn.Content = ItemEnch_cb.Text;

                FillCharacterState();
            } //Main Weapons
            else if (cs.sgn == 13)
            {
                LoadItemCaph_cb();
                if (cs.swEnchLvl >= 18) { TempCaphLvl = ItemCaph_cb.SelectedIndex; cs.swCaphLvl = TempCaphLvl; }
                if (cs.swEnchLvl >= 18 & ItemEnch_cb.SelectedIndex != cs.swEnchLvl) { ItemCaph_cb.SelectedIndex = 0; cs.swCaphLvl = 0; TempCaphLvl = 0; }
                else if (cs.swEnchLvl < 18) { cs.swCaphLvl = 0; }

                cs.swEnchLvl = ItemEnch_cb.SelectedIndex;
                cs.SubWeaponState(chSubWeapon);

                iAP_n.Content = cs.swAPlow.ToString() + '~' + cs.swAPhigh.ToString();
                iAcc_n.Content = cs.swAccuracy.ToString();
                iEAPa_n.Content = cs.swAPagainst.ToString();
                iIgnoreResistance_n.Content = cs.swIgnore.ToString();
                iDP_n.Content = cs.swDP.ToString();
                iEvas_n.Content = cs.swEvasion.ToString();
                iHEV_n.Content = cs.swHEvasion.ToString();
                iDR_n.Content = cs.swDR.ToString();
                iHP_n.Content = cs.swMaxHP.ToString();
                iMP_n.Content = cs.swMaxMP.ToString();
                iST_n.Content = cs.swMaxST.ToString();
                iRes_n.Content = cs.swAllRes.ToString();
                iST_n.Content = cs.swMaxST.ToString();
                iST_n.Content = cs.swMaxST.ToString();
                iHAP_n.Content = cs.swHidenAP.ToString();
                iSpecialAttackED_n.Content = cs.swSpecialAttackDam.ToString();
                iSpecialAttackEvRate_n.Content = cs.swSpecialAttackEv.ToString();


                if (ItemEnch_cb.SelectedIndex == 0) { SW_btn.Content = ""; }
                else if (cs.swEnch == false) SW_btn.Content = "";
                else if (ItemEnch_cb.SelectedIndex >= 1 & ItemEnch_cb.SelectedIndex <= 15) { SW_btn.Content = "+" + ItemEnch_cb.Text; }
                else SW_btn.Content = ItemEnch_cb.Text;

                FillCharacterState();
            } //Sub-Weapons
            LoadItemCaph_cb();
        }
        private void ItemCaph_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cs.sgn == 7 | cs.sgn == 8 | cs.sgn == 9 | cs.sgn == 10)
            {
                if (cs.sgn == 7) cs.armCaphLvl = ItemCaph_cb.SelectedIndex;
                if (cs.sgn == 8) cs.helCaphLvl = ItemCaph_cb.SelectedIndex;
                if (cs.sgn == 9) cs.glovCaphLvl = ItemCaph_cb.SelectedIndex;
                if (cs.sgn == 10) cs.shCaphLvl = ItemCaph_cb.SelectedIndex;
                cs.AllArmorCaphState();
                FillCharacterState();
            } // All armor

            if (cs.sgn == 11 | cs.sgn == 12 | cs.sgn == 13)
            {
                if (cs.sgn == 11) cs.awkCaphLvl = ItemCaph_cb.SelectedIndex;
                if (cs.sgn == 12) cs.mwCaphLvl = ItemCaph_cb.SelectedIndex;
                if (cs.sgn == 13) cs.swCaphLvl = ItemCaph_cb.SelectedIndex;
                cs.AllWeaponCaphState();
                FillCharacterState();
            } // Weapons
        }

     /*   private void CharacterS_btn_Click(object sender, EventArgs e)
        {
            CharacterS_gb.Visible = true;
            ShopS_gb.Visible = false;
            JournalsS_gb.Visible = false;
        }

        private void ShopS_btn_Click(object sender, EventArgs e)
        {
            ShopS_gb.Visible = true;
            ShopS_gb.Location = CharacterS_gb.Location;
            ShopS_gb.Size = CharacterS_gb.Size;
            CharacterS_gb.Visible = false;
            JournalsS_gb.Visible = false;
        }

        private void BooksS_btn_Click(object sender, EventArgs e)
        {
            JournalsS_gb.Visible = true;
            JournalsS_gb.Location = CharacterS_gb.Location;
            JournalsS_gb.Size = new Size(243, 322);
            CharacterS_gb.Visible = false;
            ShopS_gb.Visible = false;
        }

        private void Breath_tb_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Breath_tb.Text))
            {
                Breath_tb.Text = "1";
            }
            if (Convert.ToInt32(Breath_tb.Text) > 50) { Breath_tb.Text = Convert.ToString(50); }
            if (Convert.ToInt32(Breath_tb.Text) <= 0) { Breath_tb.Text = Convert.ToString(1); }
            if (Convert.ToInt32(Breath_tb.Text) <= 11) { cs.cMaxST -= cs.tcsb; cs.tcsb = 25 * Convert.ToInt32(Breath_tb.Text) - 25; cs.cMaxST += cs.tcsb; }
            if (Convert.ToInt32(Breath_tb.Text) > 11 & Convert.ToInt32(Breath_tb.Text) <= 19) { cs.cMaxST -= cs.tcsb; cs.tcsb = 10 * Convert.ToInt32(Breath_tb.Text) + 140; cs.cMaxST += cs.tcsb; }
            if (Convert.ToInt32(Breath_tb.Text) == 20) { cs.cMaxST -= cs.tcsb; cs.tcsb = 10 * Convert.ToInt32(Breath_tb.Text) + 170; cs.cMaxST += cs.tcsb; }
            if (Convert.ToInt32(Breath_tb.Text) > 20 & Convert.ToInt32(Breath_tb.Text) <= 28) { cs.cMaxST -= cs.tcsb; cs.tcsb = 10 * Convert.ToInt32(Breath_tb.Text) + 170; cs.cMaxST += cs.tcsb; }
            if (Convert.ToInt32(Breath_tb.Text) > 28 & Convert.ToInt32(Breath_tb.Text) <= 30) { cs.cMaxST -= cs.tcsb; cs.tcsb = 25 * Convert.ToInt32(Breath_tb.Text) - 250; cs.cMaxST += cs.tcsb; }
            if (Convert.ToInt32(Breath_tb.Text) > 30 & Convert.ToInt32(Breath_tb.Text) <= 40) { cs.cMaxST -= cs.tcsb; cs.tcsb = 10 * Convert.ToInt32(Breath_tb.Text) + 200; cs.cMaxST += cs.tcsb; }
            if (Convert.ToInt32(Breath_tb.Text) > 40 & Convert.ToInt32(Breath_tb.Text) <= 50) { cs.cMaxST -= cs.tcsb; cs.tcsb = 20 * Convert.ToInt32(Breath_tb.Text) - 200; cs.cMaxST += cs.tcsb; }
            FillCharacterState();
        }
        private void Breath_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
        private void Strength_tb_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Strength_tb.Text))
            {
                Strength_tb.Text = "1";
            }
            if (Convert.ToInt32(Strength_tb.Text) > 50) { Strength_tb.Text = Convert.ToString(50); }
            if (Convert.ToInt32(Strength_tb.Text) <= 0) { Strength_tb.Text = Convert.ToString(1); }

            if (Convert.ToInt32(Strength_tb.Text) <= 10) { cs.cWeight -= cs.tcss; cs.tcss = 2 * Convert.ToInt32(Strength_tb.Text) - 2; cs.cWeight += cs.tcss; }
            if (Convert.ToInt32(Strength_tb.Text) > 10 & Convert.ToInt32(Strength_tb.Text) < 20) { cs.cWeight -= cs.tcss; cs.tcss = 1 * Convert.ToInt32(Strength_tb.Text) + 8; cs.cWeight += cs.tcss; }
            if (Convert.ToInt32(Strength_tb.Text) == 20) { cs.cWeight -= cs.tcss; cs.tcss = 2 * Convert.ToInt32(Strength_tb.Text) - 11; cs.cWeight += cs.tcss; }
            if (Convert.ToInt32(Strength_tb.Text) > 20 & Convert.ToInt32(Strength_tb.Text) <= 28) { cs.cWeight -= cs.tcss; cs.tcss = 1 * Convert.ToInt32(Strength_tb.Text) + 9; cs.cWeight += cs.tcss; }
            if (Convert.ToInt32(Strength_tb.Text) > 28 & Convert.ToInt32(Strength_tb.Text) <= 30) { cs.cWeight -= cs.tcss; cs.tcss = 1.5 * Convert.ToInt32(Strength_tb.Text) - 5; cs.cWeight += cs.tcss; }
            if (Convert.ToInt32(Strength_tb.Text) > 30) { cs.cWeight -= cs.tcss; cs.tcss = 2 * Convert.ToInt32(Strength_tb.Text) - 20; cs.cWeight += cs.tcss; }
            FillCharacterState();
        }
        private void Strength_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
        private void Health_tb_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Health_tb.Text))
            {
                Health_tb.Text = "1";
            }
            if (Convert.ToInt32(Health_tb.Text) > 50) { Health_tb.Text = Convert.ToString(50); }
            if (Convert.ToInt32(Health_tb.Text) <= 0) { Health_tb.Text = Convert.ToString(1); }
            if (Convert.ToInt32(Health_tb.Text) <= 10) { cs.cMaxHP -= cs.tcsh1; cs.cMaxMP -= cs.tcsh2; cs.tcsh1 = 10 * Convert.ToInt32(Health_tb.Text) - 10; cs.tcsh2 = 10 * Convert.ToInt32(Health_tb.Text) - 10; cs.cMaxHP += cs.tcsh1; cs.cMaxMP += cs.tcsh2; }
            if (Convert.ToInt32(Health_tb.Text) > 10) { cs.cMaxHP -= cs.tcsh1; cs.cMaxMP -= cs.tcsh2; ; cs.tcsh1 = 10 * Convert.ToInt32(Health_tb.Text) - 10; cs.tcsh2 = 5 * Convert.ToInt32(Health_tb.Text) + 40; cs.cMaxHP += cs.tcsh1; cs.cMaxMP += cs.tcsh2; }
            if (Convert.ToInt32(Health_tb.Text) > 28 & Convert.ToInt32(Health_tb.Text) <= 30) { cs.cMaxHP -= cs.tcsh1; cs.cMaxMP -= cs.tcsh2; cs.tcsh1 = 10 * Convert.ToInt32(Health_tb.Text) - 10; cs.tcsh2 = 10 * Convert.ToInt32(Health_tb.Text) - 100; cs.cMaxHP += cs.tcsh1; cs.cMaxMP += cs.tcsh2; }
            if (Convert.ToInt32(Health_tb.Text) > 30) { cs.cMaxHP -= cs.tcsh1; cs.cMaxMP -= cs.tcsh2; cs.tcsh1 = 10 * Convert.ToInt32(Health_tb.Text) - 10; cs.tcsh2 = 5 * Convert.ToInt32(Health_tb.Text) + 50; cs.cMaxHP += cs.tcsh1; cs.cMaxMP += cs.tcsh2; }
            FillCharacterState();
        }
        private void Health_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void Underwear_cb_CheckedChanged(object sender, EventArgs e)
        {
            int uwluck = 1;
            if (Underwear_cb.Checked == true) { cLuck_n.Text = Convert.ToString(cs.cluck + uwluck); }
            else { cLuck_n.Text = Convert.ToString(cs.cluck - uwluck); }
            cs.cluck = Convert.ToInt32(cLuck_n.Text);
        }

        //IB journal
        private void IbCheckAll_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (ibCheckAll_cb.Checked == true)
            {
                ibChapter1_cb.Checked = true;
                ibChapter2_cb.Checked = true;
                ibChapter3_cb.Checked = true;
                ibChapter4_cb.Checked = true;
                ibChapter5_cb.Checked = true;
                ibChapter6_cb.Checked = true;
                ibChapter7_cb.Checked = true;
                ibChapter8_cb.Checked = true;
                ibChapter9_cb.Checked = true;
                ibChapter10_cb.Checked = true;
            }
            else
            {
                ibChapter1_cb.Checked = false;
                ibChapter2_cb.Checked = false;
                ibChapter3_cb.Checked = false;
                ibChapter4_cb.Checked = false;
                ibChapter5_cb.Checked = false;
                ibChapter6_cb.Checked = false;
                ibChapter7_cb.Checked = false;
                ibChapter8_cb.Checked = false;
                ibChapter9_cb.Checked = false;
                ibChapter10_cb.Checked = false;
            }
        }
        private void IbChapter1_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (ibChapter1_cb.Checked == true) { cs.cMaxHP += 6; cs.cMaxST += 5; }
            else { cs.cMaxHP -= 6; cs.cMaxST -= 5; }
            FillCharacterState();
        }
        private void IbChapter2_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (ibChapter2_cb.Checked == true) { cs.cWeight += 4; cs.cacc += 1; cs.cMaxHP += 6; cs.cMaxST += 5; }
            else { cs.cWeight -= 4; cs.cacc -= 1; cs.cMaxHP -= 6; cs.cMaxST -= 5; }
            FillCharacterState();
        }
        private void IbChapter3_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (ibChapter3_cb.Checked == true) { cs.cWeight += 2; cs.cdp += 1; cs.cMaxHP += 6; cs.cMaxST += 5; }
            else { cs.cWeight -= 2; cs.cdp -= 1; cs.cMaxHP -= 6; cs.cMaxST -= 5; }
            FillCharacterState();
        }
        private void IbChapter4_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (ibChapter4_cb.Checked == true) { cs.cMaxHP += 6; cs.cMaxST += 5; cs.cev += 2; }
            else { cs.cMaxHP -= 6; cs.cMaxST -= 5; cs.cev -= 2; }
            FillCharacterState();
        }
        private void IbChapter5_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (ibChapter5_cb.Checked == true) { cs.cWeight += 3; cs.cacc += 2; cs.cMaxHP += 3; cs.cMaxST += 5; }
            else { cs.cWeight -= 3; cs.cacc -= 2; cs.cMaxHP -= 3; cs.cMaxST -= 5; }
            FillCharacterState();
        }
        private void IbChapter6_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (ibChapter6_cb.Checked == true) { cs.cap += 1; cs.cacc += 1; cs.cMaxHP += 8; cs.cMaxST += 5; }
            else { cs.cap -= 1; cs.cacc -= 1; cs.cMaxHP -= 8; cs.cMaxST -= 5; }
            FillCharacterState();
        }
        private void IbChapter7_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (ibChapter7_cb.Checked == true) { cs.cWeight += 5; cs.cMaxHP += 6; cs.cMaxST += 10; }
            else { cs.cWeight -= 5; cs.cMaxHP -= 6; cs.cMaxST -= 10; }
            FillCharacterState();
        }
        private void IbChapter8_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (ibChapter8_cb.Checked == true) { cs.cWeight += 2; cs.cacc += 2; cs.cMaxHP += 14; cs.cev += 1; }
            else { cs.cWeight -= 2; cs.cacc -= 2; cs.cMaxHP -= 14; cs.cev -= 1; }
            FillCharacterState();
        }
        private void IbChapter9_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (ibChapter9_cb.Checked == true) { cs.cWeight += 3; cs.cacc += 2; cs.cMaxHP += 3; cs.cMaxST += 5; }
            else { cs.cWeight -= 3; cs.cacc -= 2; cs.cMaxHP -= 3; cs.cMaxST -= 5; }
            FillCharacterState();
        }
        private void IbChapter10_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (ibChapter10_cb.Checked == true) { cs.cev += 2; cs.cMaxHP += 6; cs.cMaxST += 5; }
            else { cs.cev -= 2; cs.cMaxHP -= 6; cs.cMaxST -= 5; }
            FillCharacterState();
        }
        //RT journal
        private void RtChapter1_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (rtChapter1_cb.Checked == true) { cs.cWeight += 6; cs.cMaxHP += 18; }
            else { cs.cWeight -= 6; cs.cMaxHP -= 18; }
            FillCharacterState();
        } */

    }
}
