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
            ItemCaph_cb.Visibility = Visibility.Hidden;
            Caph_lbl.Visibility = Visibility.Hidden;
            ItemEnch_cb.Visibility = Visibility.Hidden;
            Ench_lbl.Visibility = Visibility.Hidden;
            JournalsS_border.Visibility = Visibility.Hidden;

            CrysA1_btn.Visibility = Visibility.Hidden; CrysA2_btn.Visibility = Visibility.Hidden;
            CrysB1_btn.Visibility = Visibility.Hidden; CrysB2_btn.Visibility = Visibility.Hidden;
            CrysG1_btn.Visibility = Visibility.Hidden; CrysG2_btn.Visibility = Visibility.Hidden;
            CrysH1_btn.Visibility = Visibility.Hidden; CrysH2_btn.Visibility = Visibility.Hidden;
            CrysMW1_btn.Visibility = Visibility.Hidden; CrysMW2_btn.Visibility = Visibility.Hidden;
            CrysSW1_btn.Visibility = Visibility.Hidden; CrysSW2_btn.Visibility = Visibility.Hidden;
            
            MainStateLabels();
            AbilitiesLabels();
            OffenceStateLabels();
            SurvivalStateLabels();
            BonusStateLabels();
            DefenceStateLabels();
            ProffessionStateLabels();
            AdditionalStateLabels();
            OtherStateLabels();
            ItemStateLabels();
            ResistanceStateLabels();

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
            cWeight_n.Content = Convert.ToString(cs.cWeight);
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
            cAlchCookTime_n.Content = cs.cAlchCookTime.ToString() + " sec";
            cProcessingRate_n.Content = cs.cProccesingRate.ToString() + "%";
            cGathering_n.Content = cs.cGathering.ToString();
            cFishing_n.Content = cs.cFishing.ToString();
            cGathDropRate_n.Content = cs.cGathDropRate.ToString() + "%";
            cCombatEXP_n.Content = "+" + cs.cCombatExp.ToString() + "%";
            cSkillEXP_n.Content = "+" + cs.cCombatExp.ToString() + "%";
            cCHDamage_n.Content = cs.cCritHitDmg.ToString() + "%";
            cAtkSpeedDmg_n.Content = cs.cSpeedAtkDmg.ToString() + "%";
            cEDtoAir_n.Content = cs.cEDtoAir.ToString() + "%";
            cEDtoCounter_n.Content = cs.cEDtoCounter.ToString() + "%";
            cEDtoDown_n.Content = cs.cEDtoDown.ToString() + "%";
            cIgnoreGrapleResistance_n.Content = cs.cGrapResistIgnore.ToString() + "%";
            cIgnoreKBResistance_n.Content = cs.cKBResistIgnore.ToString() + "%";
            cIgnoreKDResistance_n.Content = cs.cKDResistIgnore.ToString() + "%";
            cIgnoreStunResistance_n.Content = cs.cStunResistIgnore.ToString() + "%";
            cVisionRange_n.Content = "+" + cs.cVisionRange + "m";

            cMagicDR_n.Content = cs.cMagicDR;
            cMelleDR_n.Content = cs.cMeleeDR;
            cRangeDR_n.Content = cs.cRangeDR;
            cSiegeWeaponEvRate_n.Content = cs.cSiegeWeaponEvRate + "%";

            cMagicAP_n.Content = cs.cMagicAP;
            cMelleAP_n.Content = cs.cMelleAP;
            cRangeAP_n.Content = cs.cRangeAP;

            cJump_n.Content = cs.cJump;
            cFallDamage_n.Content = cs.cFallDamage + "%";
            cUnderwaterBreath_n.Content = "+" + cs.cUnderwaterBreath + "sec";
            cMaxEnergy_n.Content = cs.cMaxEnergy;

            cBonusAP_n.Content = cs.bcap;
            cBonusAAP_n.Content = cs.bcaap;
            cBonusDR_n.Content = String.Format("{0:0}", cs.bcdr);
        }
        private void ItemStatClear()
        {
        cs.iAP = 0; 
        cs.iAAP = 0; 
        cs.iDP = 0; //DP
        cs.iEvas = 0; //Evasion
        cs.iAcc = 0; //Accuracy
        cs.iRes = 0; //All Resists
        cs.iDR = 0; // Damage Reduction
        cs.iHP = 0; // Max HP
        cs.iWeight = 0; // Max Weight
        cs.iMP = 0; //Max MP
        cs.iST = 0; //Max stamina
        cs.iSSFR = 0; // SSF Resist
        cs.iKBR = 0; // KB Resist
        cs.iGrapR = 0; // Graple Resist
        cs.iKFR = 0; //KF Resist
        cs.iHEV = 0; //Hiden Evasion
        cs.iHDR = 0; //Hiden Damage Reduction
        cs.iAtkSpeed = 0; // Attack speed
        cs.iCastSpeed = 0; //Cast speed
        cs.iMVS = 0; // Movement speed
        cs.iCrit = 0; // Critical rate
        cs.iExtraDamKama = 0; //Extra Damage to Kamasylvians
        cs.iEDtA = 0; // Extra Damage to All Species
        cs.iEAPa = 0; // Extra AP against monters
        cs.iMPR = 0; // MP Recovery
        cs.iHPR = 0; // HP Recovery
        cs.iLuck = 0; // Luck
        cs.iEDH = 0; //Extra damage to Humans
        cs.iADtDemiH = 0; // Additional damage to Demihumans
        cs.iEDtAExcHumanAndDemi = 0; //Extra damage to All Species Except Humans and Demihumans
        cs.iSpiritRage = 0; // Black Spirit's Rage
        cs.iBidding = 0; //Marketplace Bidding Success Rate
        cs.iEDtoBack = 0; // Extra damage to back
        cs.iHPRecoveryChance = 0;
        cs.iIgnoreResistance = 0;
        cs.iSpecialAttackED = 0;
        cs.iSpecialAttackEvRate = 0;
        cs.iHAP = 0;
        cs.iCastSpeedRate = 0;
        cs.iAtkSpeedRate = 0;
        cs.iAlchCookTime = 0;
        cs.iProcessingRate = 0;
        cs.iGathering = 0;
        cs.iFishing = 0;
        cs.iGathDropRate = 0;
        cs.iCombatEXP = 0;
        cs.iSkillEXP = 0;
        cs.iCHDamage = 0;
        cs.iAtkSpeedDmg = 0;
        cs.iEDtoAir = 0;
        cs.iEDtoCounter = 0;
        cs.iEDtoDown = 0;
        cs.iIgnoreGrapleResistance = 0;
        cs.iIgnoreKBResistance = 0;
        cs.iIgnoreKDResistance = 0;
        cs.iIgnoreStunResistance = 0;
        cs.iVisionRange = 0;

        cs.iMagicDR = 0;
        cs.iMelleDR = 0;
        cs.iRangeDR = 0;
        cs.iSiegeWeaponEvRate = 0;

        cs.iMagicAP = 0;
        cs.iMelleAP = 0;
        cs.iRangeAP = 0;

        cs.iJump = 0;
        cs.iFallDamage = 0;
        cs.iUnderwaterBreath = 0;
        cs.iMaxEnergy = 0;
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
            Item_Icon_Load("Alchemy Stones", cs.asId);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            SelectGear_cb.SelectedIndex = cs.asId;
            LoadItemEnch_cb();
            LoadItemCaph_cb();
        }

        private void LoadCrysMW1() // Weapon Magic Crystal 1
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"(Select Id, Name, Icon, Grade from [Weapon Magic Crystal]) union all (Select Id, Name, Icon, Grade from [Versatile Magic Crystal])";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            Item_Icon_Load(cs.wmcType + " Magic Crystal", cs.wmcId);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            if (cs.wmcType == "Versatile") SelectGear_cb.SelectedIndex = cs.wmcId + 26;
            else SelectGear_cb.SelectedIndex = cs.wmcId;
            LoadItemEnch_cb();
            LoadItemCaph_cb();
        }

        private void LoadCrysMW2()
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"(Select Id, Name, Icon, Grade from [Weapon Magic Crystal]) union all (Select Id, Name, Icon, Grade from [Versatile Magic Crystal])";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            Item_Icon_Load(cs.wmc2Type + " Magic Crystal", cs.wmc2Id);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            if (cs.wmc2Type == "Versatile") SelectGear_cb.SelectedIndex = cs.wmc2Id + 26;
            else SelectGear_cb.SelectedIndex = cs.wmc2Id;
            LoadItemEnch_cb();
            LoadItemCaph_cb();
        } // Weapon Magic Crystal 2

        private void LoadCrysSW1() // Sub-Weapon Magic Crystal 1
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"(Select Id, Name, Icon, Grade from [Sub-Weapon Magic Crystal]) union all (Select Id, Name, Icon, Grade from [Versatile Magic Crystal])";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            Item_Icon_Load(cs.swmcType + " Magic Crystal", cs.swmcId);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            if (cs.swmcType == "Versatile") SelectGear_cb.SelectedIndex = cs.swmcId + 15;
            else SelectGear_cb.SelectedIndex = cs.swmcId;
            LoadItemEnch_cb();
            LoadItemCaph_cb();
        }

        private void LoadCrysSW2()
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"(Select Id, Name, Icon, Grade from [Sub-Weapon Magic Crystal]) union all (Select Id, Name, Icon, Grade from [Versatile Magic Crystal])";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            Item_Icon_Load(cs.swmc2Type + " Magic Crystal", cs.swmc2Id);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            if (cs.swmc2Type == "Versatile") SelectGear_cb.SelectedIndex = cs.swmc2Id + 15;
            else SelectGear_cb.SelectedIndex = cs.swmc2Id;
            LoadItemEnch_cb();
            LoadItemCaph_cb();

        } // Sub-Weapon Magic Crystal 2

        private void LoadCrysH1() // Helmet Magic Crystal 1
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"(Select Id, Name, Icon, Grade from [Helmet Magic Crystal]) union all (Select Id, Name, Icon, Grade from [Versatile Magic Crystal])";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            Item_Icon_Load(cs.hmcType + " Magic Crystal", cs.hmcId);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            if (cs.hmcType == "Versatile") SelectGear_cb.SelectedIndex = cs.hmcId + 21;
            else SelectGear_cb.SelectedIndex = cs.hmcId;
            LoadItemEnch_cb();
            LoadItemCaph_cb();
        }

        private void LoadCrysH2()
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"(Select Id, Name, Icon, Grade from [Helmet Magic Crystal]) union all (Select Id, Name, Icon, Grade from [Versatile Magic Crystal])";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            Item_Icon_Load(cs.hmc2Type + " Magic Crystal", cs.hmc2Id);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            if (cs.hmc2Type == "Versatile") SelectGear_cb.SelectedIndex = cs.hmc2Id + 21;
            else SelectGear_cb.SelectedIndex = cs.hmc2Id;
            LoadItemEnch_cb();
            LoadItemCaph_cb();

        } // Helmet Magic Crystal 2

        private void LoadCrysA1() // Armor Magic Crystal 1
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"(Select Id, Name, Icon, Grade from [Armor Magic Crystal]) union all (Select Id, Name, Icon, Grade from [Versatile Magic Crystal])";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            Item_Icon_Load(cs.amcType + " Magic Crystal", cs.amcId);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            if (cs.amcType == "Versatile") SelectGear_cb.SelectedIndex = cs.amcId + 28;
            else SelectGear_cb.SelectedIndex = cs.amcId;
            LoadItemEnch_cb();
            LoadItemCaph_cb();
        }

        private void LoadCrysA2()
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"(Select Id, Name, Icon, Grade from [Armor Magic Crystal]) union all (Select Id, Name, Icon, Grade from [Versatile Magic Crystal])";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            Item_Icon_Load(cs.amc2Type + " Magic Crystal", cs.amc2Id);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            if (cs.amc2Type == "Versatile") SelectGear_cb.SelectedIndex = cs.amc2Id + 28;
            else SelectGear_cb.SelectedIndex = cs.amc2Id;
            LoadItemEnch_cb();
            LoadItemCaph_cb();

        } // Armor Magic Crystal 2

        private void LoadCrysG1() // Gloves Magic Crystal 1
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"(Select Id, Name, Icon, Grade from [Gloves Magic Crystal]) union all (Select Id, Name, Icon, Grade from [Versatile Magic Crystal])";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            Item_Icon_Load(cs.gmcType + " Magic Crystal", cs.gmcId);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            if (cs.gmcType == "Versatile") SelectGear_cb.SelectedIndex = cs.gmcId + 24;
            else SelectGear_cb.SelectedIndex = cs.gmcId;
            LoadItemEnch_cb();
            LoadItemCaph_cb();
        }

        private void LoadCrysG2()
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"(Select Id, Name, Icon, Grade from [Gloves Magic Crystal]) union all (Select Id, Name, Icon, Grade from [Versatile Magic Crystal])";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            Item_Icon_Load(cs.gmc2Type + " Magic Crystal", cs.gmc2Id);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            if (cs.gmc2Type == "Versatile") SelectGear_cb.SelectedIndex = cs.gmc2Id + 24;
            else SelectGear_cb.SelectedIndex = cs.gmc2Id;
            LoadItemEnch_cb();
            LoadItemCaph_cb();

        } // Gloves Magic Crystal 2

        private void LoadCrysS1() // Shoes Magic Crystal 1
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"(Select Id, Name, Icon, Grade from [Shoes Magic Crystal]) union all (Select Id, Name, Icon, Grade from [Versatile Magic Crystal])";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            Item_Icon_Load(cs.smcType + " Magic Crystal", cs.smcId);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            if (cs.smcType == "Versatile") SelectGear_cb.SelectedIndex = cs.smcId + 25;
            else SelectGear_cb.SelectedIndex = cs.smcId;
            LoadItemEnch_cb();
            LoadItemCaph_cb();
        }

        private void LoadCrysS2()
        {
            SelectGear_cb.SelectionChanged -= SelectGear_cb_SelectionChanged;
            var sql = @"(Select Id, Name, Icon, Grade from [Shoes Magic Crystal]) union all (Select Id, Name, Icon, Grade from [Versatile Magic Crystal])";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.ItemsSource = ds.Tables[0].DefaultView;
            Item_Icon_Load(cs.smc2Type + " Magic Crystal", cs.smc2Id);
            SelectGear_cb.SelectionChanged += SelectGear_cb_SelectionChanged;
            if (cs.smc2Type == "Versatile") SelectGear_cb.SelectedIndex = cs.smc2Id + 25;
            else SelectGear_cb.SelectedIndex = cs.smc2Id;
            LoadItemEnch_cb();
            LoadItemCaph_cb();

        } // Shoes Magic Crystal 2

        //Lvl Bonus
        private void DpLvl_cb_Checked(object sender, RoutedEventArgs e)
        {
            int lvlDP = 1;
            if (dpLvl_cb.IsChecked == true)
            {
                cDP_n.Content = Convert.ToString(cs.cdp + lvlDP);
            }
            else
            {
                cDP_n.Content = Convert.ToString(cs.cdp - lvlDP);
            }
            cs.cdp = Convert.ToInt32(cDP_n.Content);
        }

        private void ApLvl_cb_Checked(object sender, RoutedEventArgs e)
        {
            int lvlAP = 1;
            int lvlAAP = 1;
            if (apLvl_cb.IsChecked == true)
            {
                cAP_n.Content = Convert.ToString(cs.cap + lvlAP);
                cAAP_n.Content = Convert.ToString(cs.caap + lvlAAP);
            }
            else
            {
                cAP_n.Content = Convert.ToString(cs.cap - lvlAP);
                cAAP_n.Content = Convert.ToString(cs.caap - lvlAAP);
            }
            cs.cap = Convert.ToInt32(cAP_n.Content);
            cs.caap = Convert.ToInt32(cAAP_n.Content);
        }


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

        private void CrysMW1_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 15;
            LoadCrysMW1();
        }

        private void CrysMW2_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 16;
            LoadCrysMW2();
        }

        private void CrysSW1_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 17;
            LoadCrysSW1();
        }

        private void CrysSW2_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 18;
            LoadCrysSW2();
        }

        private void CrysH1_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 19;
            LoadCrysH1();
        }

        private void CrysH2_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 20;
            LoadCrysH2();
        }

        private void CrysA1_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 21;
            LoadCrysA1();
        }

        private void CrysA2_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 22;
            LoadCrysA2();
        }

        private void CrysG1_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 23;
            LoadCrysG1();
        }

        private void CrysG2_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 24;
            LoadCrysG2();
        }

        private void CrysB1_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 25;
            LoadCrysS1();
        }

        private void CrysB2_btn_Click(object sender, RoutedEventArgs e)
        {
            ItemStatClear();
            cs.sgn = 26;
            LoadCrysS2();
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
                Belt_btn.Background = new ImageBrush(Item_img.Source);
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

                cs.iAP = cs.beltap;
                cs.iDP = cs.beltdp;
                cs.iEvas = cs.beltev;
                cs.iAcc = cs.beltacc;
                cs.iRes = cs.beltResis;
                cs.iDR = cs.beltDR;
                cs.iHP = cs.beltHP;
                cs.iWeight = cs.beltWeight;
                cs.iSpiritRage = cs.beltSpiritRage;
                cs.iEAPa = cs.beltAPagaingst;


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
                Necklace_btn.Background = new ImageBrush(Item_img.Source);
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


                cs.iAP = cs.neckap;
                cs.iDP = cs.neckdp;
                cs.iEvas = cs.neckev;
                cs.iAcc = cs.neckacc;
                cs.iRes = cs.neckAllRes;
                cs.iDR = cs.neckDR;
                cs.iSSFR = cs.neckSSF;
                cs.iKBR = cs.neckKB;
                cs.iGrapR = cs.neckG ;
                cs.iKFR = cs.neckKF ;
                cs.iHP = cs.neckHP;
                cs.iSpiritRage = cs.neckSpiritRage;
                cs.iEAPa = cs.neckAPagaingst;
                cs.iExtraDamKama = cs.neckKamaDamage;
                cs.iEDtoBack = cs.neckBackDamage ;

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
                Ring1_btn.Background = new ImageBrush(Item_img.Source);
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


                cs.iAP = cs.ring1ap;
                cs.iDP = cs.ring1dp;
                cs.iEvas = cs.ring1ev;
                cs.iAcc = cs.ring1acc;
                cs.iDR = cs.ring1DR;
                cs.iHP = cs.ring1HP;
                cs.iMP = cs.ring1MP;
                cs.iST = cs.ring1ST;
                cs.iHEV = cs.ring1HEv;
                cs.iEAPa = cs.ring1APagaingst;
                cs.iExtraDamKama = cs.ring1KamaDamage;
                cs.iEDH = cs.ring1DamageHumans;
                cs.iADtDemiH = cs.ring1DamageDemihumans;
                cs.iEDtAExcHumanAndDemi =cs.ring1DamageAllExcept;
                cs.iBidding =cs.ring1Bidding;
                cs.iSpiritRage = cs.ring1SpiritRage;

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
                Ring2_btn.Background = new ImageBrush(Item_img.Source);
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

                cs.iAP = cs.ring2ap;
                cs.iDP = cs.ring2dp;
                cs.iEvas = cs.ring2ev;
                cs.iAcc = cs.ring2acc;
                cs.iDR = cs.ring2DR;
                cs.iHP = cs.ring2HP;
                cs.iMP = cs.ring2MP;
                cs.iST = cs.ring2ST;
                cs.iHEV = cs.ring2HEv;
                cs.iEAPa = cs.ring2APagaingst;
                cs.iExtraDamKama = cs.ring2KamaDamage;
                cs.iEDH = cs.ring2DamageHumans;
                cs.iADtDemiH = cs.ring2DamageDemihumans;
                cs.iEDtAExcHumanAndDemi = cs.ring2DamageAllExcept;
                cs.iBidding = cs.ring2Bidding;
                cs.iSpiritRage = cs.ring2SpiritRage;

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
                Earring1_btn.Background = new ImageBrush(Item_img.Source);
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

                cs.iAP = cs.ear1ap;
                cs.iDP = cs.ear1dp;
                cs.iEvas = cs.ear1ev;
                cs.iAcc = cs.ear1acc;
                cs.iDR = cs.ear1DR;
                cs.iHP = cs.ear1HP;
                cs.iMP = cs.ear1MP;
                cs.iST = cs.ear1ST;
                cs.iSpiritRage = cs.ear1SpiritRage;
                cs.iEAPa = cs.ear1APagaingst;
                cs.iExtraDamKama = cs.ear1KamaDamage;

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
                Earring2_btn.Background = new ImageBrush(Item_img.Source);
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

                cs.iAP = cs.ear2ap;
                cs.iDP = cs.ear2dp;
                cs.iEvas = cs.ear2ev;
                cs.iAcc = cs.ear2acc;
                cs.iDR = cs.ear2DR;
                cs.iHP = cs.ear2HP;
                cs.iMP = cs.ear2MP;
                cs.iST = cs.ear2ST;
                cs.iSpiritRage = cs.ear2SpiritRage;
                cs.iEAPa = cs.ear2APagaingst;
                cs.iExtraDamKama = cs.ear2KamaDamage;

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
                    cs.armGems = Convert.ToInt32(dr["Gems"]);
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
                Armour_btn.Background = new ImageBrush(Item_img.Source);
                cs.ArmorState();
                if (cs.armEnch == false) Armour_btn.Content = "";

                if (cs.armEnch == true && SelectGear_cb.SelectedIndex == cs.armId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.armEnchLvl = TempEnchLvl; }
                if (cs.armEnch == true && SelectGear_cb.SelectedIndex != cs.armId) { ItemEnch_cb.SelectedIndex = 0; cs.armEnchLvl = 0; TempEnchLvl = 0; ItemCaph_cb.SelectedIndex = 0; cs.armCaphLvl = 0; TempCaphLvl = 0; }
                else if (cs.armEnch == false) { cs.armEnchLvl = 0; cs.armCaphLvl = 0; }

                if (cs.armGems == 2) { CrysA1_btn.Visibility = Visibility.Visible; CrysA2_btn.Visibility = Visibility.Visible; }
                else if (cs.armGems == 1) { CrysA1_btn.Visibility = Visibility.Visible; CrysA2_btn.Visibility = Visibility.Hidden; }
                else { CrysA1_btn.Visibility = Visibility.Hidden; CrysA2_btn.Visibility = Visibility.Hidden; }

                if (cs.armId != SelectGear_cb.SelectedIndex)
                {
                    CrysA1_btn.Background = null;
                    cs.CrysA1Clear();
                    cs.CrysA1();

                    CrysA2_btn.Background = null;
                    cs.CrysA2Clear();
                    cs.CrysA2();
                }



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


                cs.iDP = cs.armdp;
                cs.iEvas = cs.armev;
                cs.iHEV = cs.armhev;
                cs.iDR = cs.armdr;
                cs.iHDR = cs.armhdr;
                cs.iHP = cs.armHP;
                cs.iMP = cs.armMP;
                cs.iSSFR = cs.armSSFRes;
                cs.iWeight = cs.armWeight;
                cs.iAcc = cs.armAcc;
                cs.iHPR = cs.armHPRecovery;
                cs.iMPR = cs.armMPRecovery;

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
                    cs.helGems = Convert.ToInt32(dr["Gems"]);
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
                Helmet_btn.Background = new ImageBrush(Item_img.Source);
                cs.HelmetState();
                if (cs.helEnch == false) Helmet_btn.Content = "";

                if (cs.helEnch == true && SelectGear_cb.SelectedIndex == cs.helId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.helEnchLvl = TempEnchLvl; }
                if (cs.helEnch == true && SelectGear_cb.SelectedIndex != cs.helId) { ItemEnch_cb.SelectedIndex = 0; cs.helEnchLvl = 0; TempEnchLvl = 0; ItemCaph_cb.SelectedIndex = 0; cs.helCaphLvl = 0; TempCaphLvl = 0; }
                else if (cs.helEnch == false) { cs.helEnchLvl = 0; cs.helCaphLvl = 0; }

                if (cs.helGems == 2) { CrysH1_btn.Visibility = Visibility.Visible; CrysH2_btn.Visibility = Visibility.Visible; }
                else if (cs.helGems == 1) { CrysH1_btn.Visibility = Visibility.Visible; CrysH2_btn.Visibility = Visibility.Hidden; }
                else { CrysH1_btn.Visibility = Visibility.Hidden; CrysH2_btn.Visibility = Visibility.Hidden; }

                if (cs.helId != SelectGear_cb.SelectedIndex)
                {
                    CrysH1_btn.Background = null;
                    cs.CrysH1Clear();
                    cs.CrysH1();

                    CrysH2_btn.Background = null;
                    cs.CrysH2Clear();
                    cs.CrysH2();
                }

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

                cs.iDP = cs.heldp;
                cs.iEvas = cs.helev;
                cs.iHEV = cs.helhev;
                cs.iDR = cs.heldr;
                cs.iHDR = cs.helhdr;
                cs.iHP = cs.helHP;
                cs.iSSFR = cs.helSSFRes;
                cs.iKBR = cs.helKBRes ;
                cs.iGrapR = cs.helGrapleRes ;
                cs.iKFR = cs.helKFRes;
                cs.iST = cs.helST;
                cs.iWeight = cs.helWeight;
                cs.iHPR = cs.helHPRecovery;
                cs.iLuck = cs.helLuck;

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
                    cs.glovGems = Convert.ToInt32(dr["Gems"]);
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
                Gloves_btn.Background = new ImageBrush(Item_img.Source);
                cs.GlovesState();
                if (cs.glovEnch == false) Gloves_btn.Content = "";

                if (cs.glovEnch == true && SelectGear_cb.SelectedIndex == cs.glovId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.glovEnchLvl = TempEnchLvl; }
                if (cs.glovEnch == true && SelectGear_cb.SelectedIndex != cs.glovId) { ItemEnch_cb.SelectedIndex = 0; cs.glovEnchLvl = 0; TempEnchLvl = 0; ItemCaph_cb.SelectedIndex = 0; cs.glovCaphLvl = 0; TempCaphLvl = 0; }
                else if (cs.glovEnch == false) { cs.glovEnchLvl = 0; cs.glovCaphLvl = 0; }

                if (cs.glovGems == 2) { CrysG1_btn.Visibility = Visibility.Visible; CrysG2_btn.Visibility = Visibility.Visible; }
                else if (cs.glovGems == 1) { CrysG1_btn.Visibility = Visibility.Visible; CrysG2_btn.Visibility = Visibility.Hidden; }
                else { CrysG1_btn.Visibility = Visibility.Hidden; CrysG2_btn.Visibility = Visibility.Hidden; }

                if (cs.glovId != SelectGear_cb.SelectedIndex)
                {
                    CrysG1_btn.Background = null;
                    cs.CrysG1Clear();
                    cs.CrysG1();

                    CrysG2_btn.Background = null;
                    cs.CrysG2Clear();
                    cs.CrysG2();
                }

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

                cs.iDP = cs.glovdp;
                cs.iEvas = cs.glovev;
                cs.iHEV = cs.glovhev;
                cs.iDR = cs.glovdr;
                cs.iHDR = cs.glovhdr;
                cs.iAcc = cs.glovacc;
                cs.iGrapR = cs.glovGrapleRes;
                cs.iAtkSpeed = cs.glovAtkSpeed;
                cs.iCastSpeed = cs.glovCastSpeed;
                cs.iCrit = cs.glovCrit;
                cs.iWeight = cs.glovWeight;
                cs.iEDtA = cs.glovDamage;

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
                    cs.shGems = Convert.ToInt32(dr["Gems"]);
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
                Boots_btn.Background = new ImageBrush(Item_img.Source);
                cs.ShoesState();
                if (cs.shEnch == false) Boots_btn.Content = "";
                if (cs.shEnch == true && SelectGear_cb.SelectedIndex == cs.shId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.shEnchLvl = TempEnchLvl; }
                if (cs.shEnch == true && SelectGear_cb.SelectedIndex != cs.shId) { ItemEnch_cb.SelectedIndex = 0; cs.shEnchLvl = 0; TempEnchLvl = 0; ItemCaph_cb.SelectedIndex = 0; cs.shCaphLvl = 0; TempCaphLvl = 0; }
                else if (cs.shEnch == false) { cs.shEnchLvl = 0; cs.shCaphLvl = 0; }

                if (cs.shGems == 2) { CrysB1_btn.Visibility = Visibility.Visible; CrysB2_btn.Visibility = Visibility.Visible; }
                else if (cs.shGems == 1) { CrysB1_btn.Visibility = Visibility.Visible; CrysB2_btn.Visibility = Visibility.Hidden; }
                else { CrysB1_btn.Visibility = Visibility.Hidden; CrysB2_btn.Visibility = Visibility.Hidden; }

                if (cs.shId != SelectGear_cb.SelectedIndex)
                {
                    CrysB1_btn.Background = null;
                    cs.CrysS1Clear();
                    cs.CrysS1();

                    CrysB2_btn.Background = null;
                    cs.CrysS2Clear();
                    cs.CrysS2();
                }

                iDP_n.Content = cs.shdp.ToString();
                iEvas_n.Content = cs.shev.ToString();
                iHEV_n.Content = cs.shhev.ToString();
                iDR_n.Content = cs.shdr.ToString();
                iHDR_n.Content = cs.shhdr.ToString();
                iKBR_n.Content = cs.shKBRes.ToString();
                iMVS_n.Content = cs.shMvs.ToString();
                iST_n.Content = cs.shMaxST.ToString();
                iWeight_n.Content = cs.shWeight.ToString();

                cs.iDP = cs.shdp;
                cs.iEvas = cs.shev;
                cs.iHEV = cs.shhev;
                cs.iDR = cs.shdr;
                cs.iHDR = cs.shhdr;
                cs.iKBR = cs.shKBRes;
                cs.iMVS = cs.shMvs;
                cs.iST = cs.shMaxST;
                cs.iWeight = cs.shWeight;

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
                AW_btn.Background = new ImageBrush(Item_img.Source);
                cs.AwakeningState(sclass);
                if (cs.awkEnch == false) AW_btn.Content = "";

                if (cs.awkEnch == true && SelectGear_cb.SelectedIndex == cs.awkId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.awkEnchLvl = TempEnchLvl; }
                if (cs.awkEnch == true && SelectGear_cb.SelectedIndex != cs.awkId) { ItemEnch_cb.SelectedIndex = 0; cs.awkEnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.awkEnch == false) { cs.awkEnchLvl = 0; }

                iAAP_n.Content = cs.awkAPlow.ToString() + '~' + cs.awkAPhigh.ToString();
                iAcc_n.Content = cs.awkAccuracy.ToString();
                iEDH_n.Content = cs.awkDamageHumans.ToString();
                iEDtA_n.Content = cs.awkDamageAll.ToString();
                iEAPa_n.Content = cs.awkAPagainst.ToString();

                cs.iAAP = (cs.awkAPlow + cs.awkAPhigh) /2;
                cs.iAcc = cs.awkAccuracy;
                cs.iEDH = cs.awkDamageHumans;
                cs.iEDtA = cs.awkDamageAll;
                cs.iEAPa = cs.awkAPagainst;

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
                    cs.mwGems = Convert.ToInt32(dr["Gems"]);
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
                MW_btn.Background = new ImageBrush(Item_img.Source);
                cs.MainWeaponState(chWeapon);
                if (cs.mwEnch == false) MW_btn.Content = "";

                if (cs.mwEnch == true && SelectGear_cb.SelectedIndex == cs.mwId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.mwEnchLvl = TempEnchLvl; }
                if (cs.mwEnch == true && SelectGear_cb.SelectedIndex != cs.mwId) { ItemEnch_cb.SelectedIndex = 0; cs.mwEnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.mwEnch == false) { cs.mwEnchLvl = 0; }

                if (cs.mwGems == 2) { CrysMW1_btn.Visibility = Visibility.Visible; CrysMW2_btn.Visibility = Visibility.Visible; }
                else if (cs.mwGems == 1) { CrysMW1_btn.Visibility = Visibility.Visible; CrysMW2_btn.Visibility = Visibility.Hidden; }
                else { CrysMW1_btn.Visibility = Visibility.Hidden; CrysMW2_btn.Visibility = Visibility.Hidden; }

                if (cs.mwId != SelectGear_cb.SelectedIndex)
                {
                    CrysMW1_btn.Background = null;
                    cs.CrysMW1Clear();
                    cs.CrysMW1();

                    CrysMW2_btn.Background = null;
                    cs.CrysMW2Clear();
                    cs.CrysMW2();
                }

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

                cs.iAP = (cs.mwAPlow + cs.mwAPhigh)/2;
                cs.iAcc = cs.mwAccuracy;
                cs.iEDH = cs.mwDamageHumans;
                cs.iEDtA = cs.mwDamageAll;
                cs.iEAPa = cs.mwAPagainst;
                cs.iADtDemiH = cs.mwDamDemi;
                cs.iAtkSpeed = cs.mwAtkSpeed;
                cs.iCastSpeed = cs.mwCastSpeed;
                cs.iCrit = cs.mwCrit;
                cs.iHPRecoveryChance = cs.mwRecoveryChance;
                cs.iIgnoreResistance = cs.mwIgnore;




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
                    cs.swGems = Convert.ToInt32(dr["Gems"]);
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
                SW_btn.Background = new ImageBrush(Item_img.Source);
                cs.SubWeaponState(chSubWeapon);
                if (cs.swEnch == false) SW_btn.Content = "";

                if (cs.swEnch == true && SelectGear_cb.SelectedIndex == cs.swId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.swEnchLvl = TempEnchLvl; }
                if (cs.swEnch == true && SelectGear_cb.SelectedIndex != cs.swId) { ItemEnch_cb.SelectedIndex = 0; cs.swEnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.swEnch == false) { cs.swEnchLvl = 0; }

                if (cs.swGems == 2) { CrysSW1_btn.Visibility = Visibility.Visible; CrysSW2_btn.Visibility = Visibility.Visible; }
                else if (cs.swGems == 1) { CrysSW1_btn.Visibility = Visibility.Visible; CrysSW2_btn.Visibility = Visibility.Hidden; }
                else { CrysSW1_btn.Visibility = Visibility.Hidden; CrysSW2_btn.Visibility = Visibility.Hidden; }

                if (cs.swId != SelectGear_cb.SelectedIndex)
                {
                    CrysSW1_btn.Background = null;
                    cs.CrysSW1Clear();
                    cs.CrysSW1();

                    CrysSW2_btn.Background = null;
                    cs.CrysSW2Clear();
                    cs.CrysSW2();
                }

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
                iHAP_n.Content = cs.swHidenAP.ToString();
                iSpecialAttackED_n.Content = cs.swSpecialAttackDam.ToString();
                iSpecialAttackEvRate_n.Content = cs.swSpecialAttackEv.ToString();

                cs.iAP = (cs.swAPlow + cs.swAPhigh)/2;
                cs.iAcc = cs.swAccuracy;
                cs.iEAPa = cs.swAPagainst;
                cs.iIgnoreResistance = cs.swIgnore;
                cs.iDP = cs.swDP;
                cs.iEvas = cs.swEvasion;
                cs.iHEV = cs.swHEvasion;
                cs.iDR = cs.swDR;
                cs.iHP = cs.swMaxHP;
                cs.iMP = cs.swMaxMP;
                cs.iST = cs.swMaxST;
                cs.iRes = cs.swAllRes;
                cs.iST = cs.swMaxST;
                cs.iHAP = cs.swHidenAP;
                cs.iSpecialAttackED = cs.swSpecialAttackDam;
                cs.iSpecialAttackEvRate = cs.swSpecialAttackEv;


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
                AS_btn.Background = new ImageBrush(Item_img.Source);
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

                cs.iAP = (cs.asAPlow +  cs.asAPhigh)/2;
                cs.iAcc = cs.asAccuracy;
                cs.iIgnoreResistance = cs.asIgnore;
                cs.iEvas = cs.asEvasion;
                cs.iDR = cs.asDR;
                cs.iHP = cs.asMaxHP;
                cs.iRes = cs.asAllRes ;
                cs.iHAP = cs.asHidenAP;
                cs.iWeight = cs.asWeightLimit;
                cs.iCastSpeedRate = cs.asCastSpeed;
                cs.iAtkSpeedRate = cs.asAtkSpeed;
                cs.iAlchCookTime = cs.asAlchCookTime;
                cs.iProcessingRate = cs.asProcRate;
                cs.iGathering = cs.asGathFish;
                cs.iFishing = cs.asGathFish;
                cs.iGathDropRate = cs.asGathDropRate;

                cs.asId = SelectGear_cb.SelectedIndex;
                LoadItemEnch_cb();

            } //Alchemy Stones
            if (cs.sgn == 15)
            {
                if (SelectGear_cb.SelectedIndex <= 25)
                {
                    cmd.CommandText = "select * from [Weapon Magic Crystal] where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.wmcId = Convert.ToInt32(dr["Id"]);
                        cs.wmcType = Convert.ToString(dr["Type"]);
                        cs.wmcDefCrit = Convert.ToInt32(dr["Crit"]);
                        cs.wmcDefCastSpeed = Convert.ToInt32(dr["CastSpeed"]);
                        cs.wmcDefAtkSpeed = Convert.ToInt32(dr["AtkSpeed"]);
                        cs.wmcDefHidenAP = Convert.ToInt32(dr["HidenAP"]);
                        cs.wmcDefIgnoreAll = Convert.ToInt32(dr["IgnoreAllRes"]);
                        cs.wmcDefAccuracy = Convert.ToInt32(dr["Accuracy"]);
                        cs.wmcDefDmgToHumans = Convert.ToInt32(dr["DamageToHumans"]);

                        cs.wmcDefDmgToDemi = 0;
                        cs.wmcDefWeight = 0;
                        cs.wmcDefAllRes = 0;
                        cs.wmcDefMaxHP = 0;
                        cs.wmcDefMaxST = 0;
                        cs.wmcDefDR = 0;
                        cs.wmcDefLuck = 0;
                        cs.wmcDefCombatEXP = 0;
                        cs.wmcDefSkillEXP = 0;
                    }
                }

                else
                {
                    cmd.CommandText = "select * from [Versatile Magic Crystal] where Id='" + (SelectGear_cb.SelectedIndex - 26).ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.wmcId = Convert.ToInt32(dr["Id"]);
                        cs.wmcType = Convert.ToString(dr["Type"]);
                        cs.wmcDefIgnoreAll = Convert.ToInt32(dr["IgnoreAllRes"]);
                        cs.wmcDefAccuracy = Convert.ToInt32(dr["Accuracy"]);
                        cs.wmcDefDmgToHumans = Convert.ToInt32(dr["DamageToHumans"]);
                        cs.wmcDefDmgToDemi = Convert.ToInt32(dr["DamageToDemi"]);
                        cs.wmcDefWeight = Convert.ToInt32(dr["WeightLimit"]);
                        cs.wmcDefAllRes = Convert.ToInt32(dr["AllRes"]);
                        cs.wmcDefMaxHP = Convert.ToInt32(dr["MaxHP"]);
                        cs.wmcDefMaxST = Convert.ToInt32(dr["MaxST"]);
                        cs.wmcDefDR = Convert.ToInt32(dr["DR"]);
                        cs.wmcDefLuck = Convert.ToInt32(dr["Luck"]);
                        cs.wmcDefCombatEXP = Convert.ToInt32(dr["CombatEXP"]);
                        cs.wmcDefSkillEXP = Convert.ToInt32(dr["SkillEXP"]);
                        cs.CrysMW1SB = Convert.ToInt32(dr["SetBonus"]);

                        cs.wmcDefCrit = 0;
                        cs.wmcDefCastSpeed = 0;
                        cs.wmcDefAtkSpeed = 0;
                        cs.wmcDefHidenAP = 0;

                    }
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = cs.wmcType + " Magic Crystal";
                Item_Icon_Load(cs.Type, cs.wmcId);
                CrysMW1_btn.Background = new ImageBrush(Item_img.Source);
                cs.CrysMW1();



                iAcc_n.Content = cs.wmcAccuracy.ToString();
                iIgnoreResistance_n.Content = cs.wmcIgnoreAll.ToString();
                iDR_n.Content = cs.wmcDR.ToString();
                iHP_n.Content = cs.wmcMaxHP.ToString();
                iRes_n.Content = cs.wmcAllRes.ToString() + "%";
                iHAP_n.Content = cs.wmcHidenAP.ToString();
                iWeight_n.Content = cs.wmcWeight.ToString();
                iCastSpeed_n.Content = cs.wmcCastSpeed.ToString();
                iAtkSpeed_n.Content = cs.wmcAtkSpeed.ToString();
                iADtDemiH_n.Content = cs.wmcDmgToDemi.ToString();
                iST_n.Content = cs.wmcMaxST.ToString();
                iLuck_n.Content = cs.wmcLuck.ToString();
                iCombatEXP_n.Content = "+" + cs.wmcCombatEXP.ToString() + "%";
                iSkillEXP_n.Content = "+" + cs.wmcSkillEXP.ToString() + "%";
                iCrit_n.Content = cs.wmcCrit.ToString();
                iEDH_n.Content = cs.wmcDmgToHumans.ToString();

                cs.iAcc = cs.wmcAccuracy;
                cs.iIgnoreResistance = cs.wmcIgnoreAll;
                cs.iDR = cs.wmcDR;
                cs.iHP = cs.wmcMaxHP;
                cs.iRes = cs.wmcAllRes ;
                cs.iHAP = cs.wmcHidenAP;
                cs.iWeight = cs.wmcWeight;
                cs.iCastSpeed = cs.wmcCastSpeed;
                cs.iAtkSpeed = cs.wmcAtkSpeed;
                cs.iADtDemiH = cs.wmcDmgToDemi;
                cs.iST = cs.wmcMaxST;
                cs.iLuck = cs.wmcLuck;
                cs.iCombatEXP = cs.wmcCombatEXP ;
                cs.iSkillEXP = cs.wmcSkillEXP;
                cs.iCrit = cs.wmcCrit;
                cs.iEDH = cs.wmcDmgToHumans;



                LoadItemEnch_cb();

            } //Weapon Magic Crystal - 1
            if (cs.sgn == 16)
            {
                if (SelectGear_cb.SelectedIndex <= 25)
                {
                    cmd.CommandText = "select * from [Weapon Magic Crystal] where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.wmc2Id = Convert.ToInt32(dr["Id"]);
                        cs.wmc2Type = Convert.ToString(dr["Type"]);
                        cs.wmc2DefCrit = Convert.ToInt32(dr["Crit"]);
                        cs.wmc2DefCastSpeed = Convert.ToInt32(dr["CastSpeed"]);
                        cs.wmc2DefAtkSpeed = Convert.ToInt32(dr["AtkSpeed"]);
                        cs.wmc2DefHidenAP = Convert.ToInt32(dr["HidenAP"]);
                        cs.wmc2DefIgnoreAll = Convert.ToInt32(dr["IgnoreAllRes"]);
                        cs.wmc2DefAccuracy = Convert.ToInt32(dr["Accuracy"]);
                        cs.wmc2DefDmgToHumans = Convert.ToInt32(dr["DamageToHumans"]);

                        cs.wmc2DefDmgToDemi = 0;
                        cs.wmc2DefWeight = 0;
                        cs.wmc2DefAllRes = 0;
                        cs.wmc2DefMaxHP = 0;
                        cs.wmc2DefMaxST = 0;
                        cs.wmc2DefDR = 0;
                        cs.wmc2DefLuck = 0;
                        cs.wmc2DefCombatEXP = 0;
                        cs.wmc2DefSkillEXP = 0;
                    }
                }

                else
                {
                    cmd.CommandText = "select * from [Versatile Magic Crystal] where Id='" + (SelectGear_cb.SelectedIndex - 26).ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.wmc2Id = Convert.ToInt32(dr["Id"]);
                        cs.wmc2Type = Convert.ToString(dr["Type"]);
                        cs.wmc2DefIgnoreAll = Convert.ToInt32(dr["IgnoreAllRes"]);
                        cs.wmc2DefAccuracy = Convert.ToInt32(dr["Accuracy"]);
                        cs.wmc2DefDmgToHumans = Convert.ToInt32(dr["DamageToHumans"]);
                        cs.wmc2DefDmgToDemi = Convert.ToInt32(dr["DamageToDemi"]);
                        cs.wmc2DefWeight = Convert.ToInt32(dr["WeightLimit"]);
                        cs.wmc2DefAllRes = Convert.ToInt32(dr["AllRes"]);
                        cs.wmc2DefMaxHP = Convert.ToInt32(dr["MaxHP"]);
                        cs.wmc2DefMaxST = Convert.ToInt32(dr["MaxST"]);
                        cs.wmc2DefDR = Convert.ToInt32(dr["DR"]);
                        cs.wmc2DefLuck = Convert.ToInt32(dr["Luck"]);
                        cs.wmc2DefCombatEXP = Convert.ToInt32(dr["CombatEXP"]);
                        cs.wmc2DefSkillEXP = Convert.ToInt32(dr["SkillEXP"]);
                        cs.CrysMW2SB = Convert.ToInt32(dr["SetBonus"]);

                        cs.wmc2DefCrit = 0;
                        cs.wmc2DefCastSpeed = 0;
                        cs.wmc2DefAtkSpeed = 0;
                        cs.wmc2DefHidenAP = 0;

                    }
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = cs.wmc2Type + " Magic Crystal";
                Item_Icon_Load(cs.Type, cs.wmc2Id);
                CrysMW2_btn.Background = new ImageBrush(Item_img.Source);
                cs.CrysMW2();



                iAcc_n.Content = cs.wmc2Accuracy.ToString();
                iIgnoreResistance_n.Content = cs.wmc2IgnoreAll.ToString();
                iDR_n.Content = cs.wmc2DR.ToString();
                iHP_n.Content = cs.wmc2MaxHP.ToString();
                iRes_n.Content = cs.wmc2AllRes.ToString() + "%";
                iHAP_n.Content = cs.wmc2HidenAP.ToString();
                iWeight_n.Content = cs.wmc2Weight.ToString();
                iCastSpeed_n.Content = cs.wmc2CastSpeed.ToString();
                iAtkSpeed_n.Content = cs.wmc2AtkSpeed.ToString();
                iADtDemiH_n.Content = cs.wmc2DmgToDemi.ToString();
                iST_n.Content = cs.wmc2MaxST.ToString();
                iLuck_n.Content = cs.wmc2Luck.ToString();
                iCombatEXP_n.Content = "+" + cs.wmc2CombatEXP.ToString() + "%";
                iSkillEXP_n.Content = "+" + cs.wmc2SkillEXP.ToString() + "%";
                iCrit_n.Content = cs.wmc2Crit.ToString();
                iEDH_n.Content = cs.wmc2DmgToHumans.ToString();

                cs.iAcc = cs.wmc2Accuracy;
                cs.iIgnoreResistance = cs.wmc2IgnoreAll;
                cs.iDR = cs.wmc2DR;
                cs.iHP = cs.wmc2MaxHP;
                cs.iRes = cs.wmc2AllRes ;
                cs.iHAP = cs.wmc2HidenAP;
                cs.iWeight = cs.wmc2Weight;
                cs.iCastSpeed = cs.wmc2CastSpeed;
                cs.iAtkSpeed = cs.wmc2AtkSpeed;
                cs.iADtDemiH = cs.wmc2DmgToDemi;
                cs.iST = cs.wmc2MaxST;
                cs.iLuck = cs.wmc2Luck;
                cs.iCombatEXP =cs.wmc2CombatEXP;
                cs.iSkillEXP = cs.wmc2SkillEXP ;
                cs.iCrit = cs.wmc2Crit;
                cs.iEDH = cs.wmc2DmgToHumans;



                LoadItemEnch_cb();

            } //Weapon Magic Crystal - 2
            if (cs.sgn == 17)
            {
                if (SelectGear_cb.SelectedIndex <= 14)
                {
                    cmd.CommandText = "select * from [Sub-Weapon Magic Crystal] where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.swmcId = Convert.ToInt32(dr["Id"]);
                        cs.swmcType = Convert.ToString(dr["Type"]);
                        cs.swmcDefMaxHP = Convert.ToInt32(dr["MaxHP"]);
                        cs.swmcDefHidenAP = Convert.ToInt32(dr["HidenAP"]);
                        cs.swmcDefDR = Convert.ToInt32(dr["DR"]);
                        cs.swmcDefIgnoreAll = 0;
                        cs.swmcDefAccuracy = 0;
                        cs.swmcDefDmgToHumans = Convert.ToInt32(dr["DmgToHumans"]); ;
                        cs.swmcDefDmgToDemi = 0;
                        cs.swmcDefWeight = 0;
                        cs.swmcDefAllRes = 0;
                        cs.swmcDefMaxST = 0;
                        cs.swmcDefLuck = 0;
                        cs.swmcDefCombatEXP = 0;
                        cs.swmcDefSkillEXP = 0;

                        cs.swmcDefCritDmg = Convert.ToInt32(dr["CritChance"]);
                        cs.swmcDefAirDmg = Convert.ToInt32(dr["AirAttackDmg"]);
                        cs.swmcDefBackDmg = Convert.ToInt32(dr["BackAttackDmg"]);
                        cs.swmcDefDownDmg = Convert.ToInt32(dr["DownAttackDmg"]);
                        cs.swmcDefCounterDmg = Convert.ToInt32(dr["CounterAttackDmg"]);
                        cs.swmcDefSpeedAtkDmg = Convert.ToInt32(dr["SpeedAttackDmg"]);
                        cs.swmcDefGrapResIgnore = Convert.ToInt32(dr["IgnoreGrapRes"]);
                        cs.swmcDefKBResIgnore = Convert.ToInt32(dr["IgnoreKBRes"]);
                        cs.swmcDefKDResIgnore = Convert.ToInt32(dr["IgnoreKDRes"]);
                        cs.swmcDefStunResIgnore = Convert.ToInt32(dr["IgnoreStunRes"]);

                    }
                }

                else
                {
                    cmd.CommandText = "select * from [Versatile Magic Crystal] where Id='" + (SelectGear_cb.SelectedIndex - 15).ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.swmcId = Convert.ToInt32(dr["Id"]);
                        cs.swmcType = Convert.ToString(dr["Type"]);
                        cs.swmcDefIgnoreAll = Convert.ToInt32(dr["IgnoreAllRes"]);
                        cs.swmcDefAccuracy = Convert.ToInt32(dr["Accuracy"]);
                        cs.swmcDefDmgToHumans = Convert.ToInt32(dr["DamageToHumans"]);
                        cs.swmcDefDmgToDemi = Convert.ToInt32(dr["DamageToDemi"]);
                        cs.swmcDefWeight = Convert.ToInt32(dr["WeightLimit"]);
                        cs.swmcDefAllRes = Convert.ToInt32(dr["AllRes"]);
                        cs.swmcDefMaxHP = Convert.ToInt32(dr["MaxHP"]);
                        cs.swmcDefMaxST = Convert.ToInt32(dr["MaxST"]);
                        cs.swmcDefDR = Convert.ToInt32(dr["DR"]);
                        cs.swmcDefLuck = Convert.ToInt32(dr["Luck"]);
                        cs.swmcDefCombatEXP = Convert.ToInt32(dr["CombatEXP"]);
                        cs.swmcDefSkillEXP = Convert.ToInt32(dr["SkillEXP"]);
                        cs.CrysSW1SB = Convert.ToInt32(dr["SetBonus"]);

                        cs.swmcDefCritDmg = 0;
                        cs.swmcDefAirDmg = 0;
                        cs.swmcDefBackDmg = 0;
                        cs.swmcDefDownDmg = 0;
                        cs.swmcDefCounterDmg = 0;
                        cs.swmcDefSpeedAtkDmg = 0;
                        cs.swmcDefGrapResIgnore = 0;
                        cs.swmcDefKBResIgnore = 0;
                        cs.swmcDefKDResIgnore = 0;
                        cs.swmcDefStunResIgnore = 0;
                        cs.swmc2DefHidenAP = 0;



                    }
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = cs.swmcType + " Magic Crystal";
                Item_Icon_Load(cs.Type, cs.swmcId);
                CrysSW1_btn.Background = new ImageBrush(Item_img.Source);
                cs.CrysSW1();



                iAcc_n.Content = cs.swmcAccuracy.ToString();
                iIgnoreResistance_n.Content = cs.swmcIgnoreAll.ToString();
                iDR_n.Content = cs.swmcDR.ToString();
                iHP_n.Content = cs.swmcMaxHP.ToString();
                iRes_n.Content = cs.swmcAllRes.ToString() + "%";
                iHAP_n.Content = cs.swmcHidenAP.ToString();
                iWeight_n.Content = cs.swmcWeight.ToString();

                iADtDemiH_n.Content = cs.swmcDmgToDemi.ToString();
                iST_n.Content = cs.swmcMaxST.ToString();
                iLuck_n.Content = cs.swmcLuck.ToString();
                iCombatEXP_n.Content = "+" + cs.swmcCombatEXP.ToString() + "%";
                iSkillEXP_n.Content = "+" + cs.swmcSkillEXP.ToString() + "%";
                iEDH_n.Content = cs.swmcDmgToHumans.ToString();

                iCHDamage_n.Content = "+" + cs.swmcCritDmg + "%";
                iAtkSpeedDmg_n.Content = "+" + cs.swmcSpeedAtkDmg + "%";
                iEDtoAir_n.Content = "+" + cs.swmcAirDmg + "%";
                iEDtoCounter_n.Content = "+" + cs.swmcCounterDmg + "%";
                iEDtoDown_n.Content = "+" + cs.swmcDownDmg + "%";
                iEDtoBack_n.Content = "+" + cs.swmcBackDmg + "%";
                iIgnoreGrapleResistance_n.Content = "+" + cs.swmcGrapResIgnore + "%";
                iIgnoreKBResistance_n.Content = "+" + cs.swmcKBResIgnore + "%";
                iIgnoreKDResistance_n.Content = "+" + cs.swmcKDResIgnore + "%";
                iIgnoreStunResistance_n.Content = "+" + cs.swmcStunResIgnore + "%";

               cs.iAcc = cs.swmcAccuracy;
                cs.iIgnoreResistance = cs.swmcIgnoreAll;
                cs.iDR = cs.swmcDR;
                cs.iHP = cs.swmcMaxHP;
                cs.iRes = cs.swmcAllRes ;
                cs.iHAP = cs.swmcHidenAP;
                cs.iWeight = cs.swmcWeight;

                cs.iADtDemiH = cs.swmcDmgToDemi;
                cs.iST = cs.swmcMaxST;
                cs.iLuck = cs.swmcLuck;
                cs.iCombatEXP =  cs.swmcCombatEXP ;
                cs.iSkillEXP =  cs.swmcSkillEXP ;
                cs.iEDH = cs.swmcDmgToHumans;

                cs.iCHDamage =  cs.swmcCritDmg ;
                cs.iAtkSpeedDmg =  cs.swmcSpeedAtkDmg ;
                cs.iEDtoAir =  cs.swmcAirDmg ;
                cs.iEDtoCounter =  cs.swmcCounterDmg ;
                cs.iEDtoDown =  cs.swmcDownDmg ;
                cs.iEDtoBack =  cs.swmcBackDmg ;
                cs.iIgnoreGrapleResistance =  cs.swmcGrapResIgnore ;
                cs.iIgnoreKBResistance =  cs.swmcKBResIgnore ;
                cs.iIgnoreKDResistance =  cs.swmcKDResIgnore ;
                cs.iIgnoreStunResistance =  cs.swmcStunResIgnore ;



                LoadItemEnch_cb();

            } //Sub-Weapon Magic Crystal - 1
            if (cs.sgn == 18)
            {
                if (SelectGear_cb.SelectedIndex <= 14)
                {
                    cmd.CommandText = "select * from [Sub-Weapon Magic Crystal] where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.swmc2Id = Convert.ToInt32(dr["Id"]);
                        cs.swmc2Type = Convert.ToString(dr["Type"]);
                        cs.swmc2DefMaxHP = Convert.ToInt32(dr["MaxHP"]);
                        cs.swmc2DefHidenAP = Convert.ToInt32(dr["HidenAP"]);
                        cs.swmc2DefDR = Convert.ToInt32(dr["DR"]);
                        cs.swmc2DefIgnoreAll = 0;
                        cs.swmc2DefAccuracy = 0;
                        cs.swmc2DefDmgToHumans = Convert.ToInt32(dr["DmgToHumans"]); ;
                        cs.swmc2DefDmgToDemi = 0;
                        cs.swmc2DefWeight = 0;
                        cs.swmc2DefAllRes = 0;
                        cs.swmc2DefMaxST = 0;
                        cs.swmc2DefLuck = 0;
                        cs.swmc2DefCombatEXP = 0;
                        cs.swmc2DefSkillEXP = 0;

                        cs.swmc2DefCritDmg = Convert.ToInt32(dr["CritChance"]);
                        cs.swmc2DefAirDmg = Convert.ToInt32(dr["AirAttackDmg"]);
                        cs.swmc2DefBackDmg = Convert.ToInt32(dr["BackAttackDmg"]);
                        cs.swmc2DefDownDmg = Convert.ToInt32(dr["DownAttackDmg"]);
                        cs.swmc2DefCounterDmg = Convert.ToInt32(dr["CounterAttackDmg"]);
                        cs.swmc2DefSpeedAtkDmg = Convert.ToInt32(dr["SpeedAttackDmg"]);
                        cs.swmc2DefGrapResIgnore = Convert.ToInt32(dr["IgnoreGrapRes"]);
                        cs.swmc2DefKBResIgnore = Convert.ToInt32(dr["IgnoreKBRes"]);
                        cs.swmc2DefKDResIgnore = Convert.ToInt32(dr["IgnoreKDRes"]);
                        cs.swmc2DefStunResIgnore = Convert.ToInt32(dr["IgnoreStunRes"]);

                    }
                }

                else
                {
                    cmd.CommandText = "select * from [Versatile Magic Crystal] where Id='" + (SelectGear_cb.SelectedIndex - 15).ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.swmc2Id = Convert.ToInt32(dr["Id"]);
                        cs.swmc2Type = Convert.ToString(dr["Type"]);
                        cs.swmc2DefIgnoreAll = Convert.ToInt32(dr["IgnoreAllRes"]);
                        cs.swmc2DefAccuracy = Convert.ToInt32(dr["Accuracy"]);
                        cs.swmc2DefDmgToHumans = Convert.ToInt32(dr["DamageToHumans"]);
                        cs.swmc2DefDmgToDemi = Convert.ToInt32(dr["DamageToDemi"]);
                        cs.swmc2DefWeight = Convert.ToInt32(dr["WeightLimit"]);
                        cs.swmc2DefAllRes = Convert.ToInt32(dr["AllRes"]);
                        cs.swmc2DefMaxHP = Convert.ToInt32(dr["MaxHP"]);
                        cs.swmc2DefMaxST = Convert.ToInt32(dr["MaxST"]);
                        cs.swmc2DefDR = Convert.ToInt32(dr["DR"]);
                        cs.swmc2DefLuck = Convert.ToInt32(dr["Luck"]);
                        cs.swmc2DefCombatEXP = Convert.ToInt32(dr["CombatEXP"]);
                        cs.swmc2DefSkillEXP = Convert.ToInt32(dr["SkillEXP"]);
                        cs.CrysSW2SB = Convert.ToInt32(dr["SetBonus"]);

                        cs.swmc2DefCritDmg = 0;
                        cs.swmc2DefAirDmg = 0;
                        cs.swmc2DefBackDmg = 0;
                        cs.swmc2DefDownDmg = 0;
                        cs.swmc2DefCounterDmg = 0;
                        cs.swmc2DefSpeedAtkDmg = 0;
                        cs.swmc2DefGrapResIgnore = 0;
                        cs.swmc2DefKBResIgnore = 0;
                        cs.swmc2DefKDResIgnore = 0;
                        cs.swmc2DefStunResIgnore = 0;
                        cs.swmc2DefHidenAP = 0;


                    }
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = cs.swmc2Type + " Magic Crystal";
                Item_Icon_Load(cs.Type, cs.swmc2Id);
                CrysSW2_btn.Background = new ImageBrush(Item_img.Source);
                cs.CrysSW2();



                iAcc_n.Content = cs.swmc2Accuracy.ToString();
                iIgnoreResistance_n.Content = cs.swmc2IgnoreAll.ToString();
                iDR_n.Content = cs.swmc2DR.ToString();
                iHP_n.Content = cs.swmc2MaxHP.ToString();
                iRes_n.Content = cs.swmc2AllRes.ToString() + "%";
                iHAP_n.Content = cs.swmc2HidenAP.ToString();
                iWeight_n.Content = cs.swmc2Weight.ToString();

                iADtDemiH_n.Content = cs.swmc2DmgToDemi.ToString();
                iST_n.Content = cs.swmc2MaxST.ToString();
                iLuck_n.Content = cs.swmc2Luck.ToString();
                iCombatEXP_n.Content = "+" + cs.swmc2CombatEXP.ToString() + "%";
                iSkillEXP_n.Content = "+" + cs.swmc2SkillEXP.ToString() + "%";
                iEDH_n.Content = cs.swmc2DmgToHumans.ToString();

                iCHDamage_n.Content = "+" + cs.swmc2CritDmg + "%";
                iAtkSpeedDmg_n.Content = "+" + cs.swmc2SpeedAtkDmg + "%";
                iEDtoAir_n.Content = "+" + cs.swmc2AirDmg + "%";
                iEDtoCounter_n.Content = "+" + cs.swmc2CounterDmg + "%";
                iEDtoDown_n.Content = "+" + cs.swmc2DownDmg + "%";
                iEDtoBack_n.Content = "+" + cs.swmc2BackDmg + "%";
                iIgnoreGrapleResistance_n.Content = "+" + cs.swmc2GrapResIgnore + "%";
                iIgnoreKBResistance_n.Content = "+" + cs.swmc2KBResIgnore + "%";
                iIgnoreKDResistance_n.Content = "+" + cs.swmc2KDResIgnore + "%";
                iIgnoreStunResistance_n.Content = "+" + cs.swmc2StunResIgnore + "%";


                cs.iAcc = cs.swmc2Accuracy;
                cs.iIgnoreResistance = cs.swmc2IgnoreAll;
                cs.iDR = cs.swmc2DR;
                cs.iHP = cs.swmc2MaxHP;
                cs.iRes = cs.swmc2AllRes ;
                cs.iHAP = cs.swmc2HidenAP;
                cs.iWeight = cs.swmc2Weight;

                cs.iADtDemiH = cs.swmc2DmgToDemi;
                cs.iST = cs.swmc2MaxST;
                cs.iLuck = cs.swmc2Luck;
                cs.iCombatEXP =  cs.swmc2CombatEXP ;
                cs.iSkillEXP =  cs.swmc2SkillEXP ;
                cs.iEDH = cs.swmc2DmgToHumans;

                cs.iCHDamage =  cs.swmc2CritDmg ;
                cs.iAtkSpeedDmg =  cs.swmc2SpeedAtkDmg ;
                cs.iEDtoAir =  cs.swmc2AirDmg ;
                cs.iEDtoCounter =  cs.swmc2CounterDmg ;
                cs.iEDtoDown =  cs.swmc2DownDmg ;
                cs.iEDtoBack =  cs.swmc2BackDmg ;
                cs.iIgnoreGrapleResistance =  cs.swmc2GrapResIgnore ;
                cs.iIgnoreKBResistance =  cs.swmc2KBResIgnore ;
                cs.iIgnoreKDResistance =  cs.swmc2KDResIgnore ;
                cs.iIgnoreStunResistance =  cs.swmc2StunResIgnore ;


                LoadItemEnch_cb();

            } //Sub-Weapon Magic Crystal - 2
            if (cs.sgn == 19)
            {
                if (SelectGear_cb.SelectedIndex <= 20)
                {
                    cmd.CommandText = "select * from [Helmet Magic Crystal] where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.hmcId = Convert.ToInt32(dr["Id"]);
                        cs.hmcType = Convert.ToString(dr["Type"]);
                        cs.hmcDefMaxHP = Convert.ToInt32(dr["MaxHP"]);
                        cs.hmcDefDR = 0;
                        cs.hmcDefIgnoreAll = 0;
                        cs.hmcDefAccuracy = 0;
                        cs.hmcDefDmgToHumans = Convert.ToInt32(dr["DmgToHumans"]);
                        cs.hmcDefDmgToDemi = 0;
                        cs.hmcDefWeight = 0;
                        cs.hmcDefAllRes = 0;
                        cs.hmcDefMaxST = 0;
                        cs.hmcDefLuck = 0;
                        cs.hmcDefCombatEXP = Convert.ToInt32(dr["CombatEXP"]);
                        cs.hmcDefSkillEXP = 0;

                        cs.hmcDefHPRecovery = Convert.ToInt32(dr["HPRecovery"]);
                        cs.hmcDefEV = Convert.ToInt32(dr["Evasion"]);
                        cs.hmcDefKBRes = Convert.ToInt32(dr["KBRes"]);
                        cs.hmcDefSSFRes = Convert.ToInt32(dr["SSFRes"]);
                        cs.hmcDefCastSpeed = Convert.ToInt32(dr["CastSpeed"]);
                        cs.hmcDefVisionRange = Convert.ToInt32(dr["VisionRange"]);



                    }
                }

                else
                {
                    cmd.CommandText = "select * from [Versatile Magic Crystal] where Id='" + (SelectGear_cb.SelectedIndex - 21).ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.hmcId = Convert.ToInt32(dr["Id"]);
                        cs.hmcType = Convert.ToString(dr["Type"]);
                        cs.hmcDefIgnoreAll = Convert.ToInt32(dr["IgnoreAllRes"]);
                        cs.hmcDefAccuracy = Convert.ToInt32(dr["Accuracy"]);
                        cs.hmcDefDmgToHumans = Convert.ToInt32(dr["DamageToHumans"]);
                        cs.hmcDefDmgToDemi = Convert.ToInt32(dr["DamageToDemi"]);
                        cs.hmcDefWeight = Convert.ToInt32(dr["WeightLimit"]);
                        cs.hmcDefAllRes = Convert.ToInt32(dr["AllRes"]);
                        cs.hmcDefMaxHP = Convert.ToInt32(dr["MaxHP"]);
                        cs.hmcDefMaxST = Convert.ToInt32(dr["MaxST"]);
                        cs.hmcDefDR = Convert.ToInt32(dr["DR"]);
                        cs.hmcDefLuck = Convert.ToInt32(dr["Luck"]);
                        cs.hmcDefCombatEXP = Convert.ToInt32(dr["CombatEXP"]);
                        cs.hmcDefSkillEXP = Convert.ToInt32(dr["SkillEXP"]);
                        cs.CrysH1SB = Convert.ToInt32(dr["SetBonus"]);


                        cs.hmcDefHPRecovery = 0;
                        cs.hmcDefEV = 0;
                        cs.hmcDefKBRes = 0;
                        cs.hmcDefSSFRes = 0;
                        cs.hmcDefCastSpeed = 0;
                        cs.hmcDefVisionRange = 0;
                    }
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = cs.hmcType + " Magic Crystal";
                Item_Icon_Load(cs.Type, cs.hmcId);
                CrysH1_btn.Background = new ImageBrush(Item_img.Source);
                cs.CrysH1();



                iAcc_n.Content = cs.hmcAccuracy.ToString();
                iIgnoreResistance_n.Content = cs.hmcIgnoreAll.ToString();
                iDR_n.Content = cs.hmcDR.ToString();
                iHP_n.Content = cs.hmcMaxHP.ToString();
                iRes_n.Content = cs.hmcAllRes.ToString() + "%";
                iWeight_n.Content = cs.hmcWeight.ToString();

                iADtDemiH_n.Content = cs.hmcDmgToDemi.ToString();
                iST_n.Content = cs.hmcMaxST.ToString();
                iLuck_n.Content = cs.hmcLuck.ToString();
                iCombatEXP_n.Content = "+" + cs.hmcCombatEXP.ToString() + "%";
                iSkillEXP_n.Content = "+" + cs.hmcSkillEXP.ToString() + "%";
                iEDH_n.Content = cs.hmcDmgToHumans.ToString();

                iHPR_n.Content = "+" + cs.hmcHPRecovery;
                iEvas_n.Content = "+" + cs.hmcEV;
                iKBR_n.Content = "+" + cs.hmcKBRes + "%";
                iSSFR_n.Content = "+" + cs.hmcSSFRes + "%";
                iCastSpeed_n.Content = "+" + cs.hmcCastSpeed;
                iVisionRange_n.Content = "+" + cs.hmcVisionRange + "m";


                cs.iAcc = cs.hmcAccuracy;
                cs.iIgnoreResistance = cs.hmcIgnoreAll;
                cs.iDR = cs.hmcDR;
                cs.iHP = cs.hmcMaxHP;
                cs.iRes = cs.hmcAllRes ;
                cs.iWeight = cs.hmcWeight;

                cs.iADtDemiH = cs.hmcDmgToDemi;
                cs.iST = cs.hmcMaxST;
                cs.iLuck = cs.hmcLuck;
                cs.iCombatEXP =  cs.hmcCombatEXP ;
                cs.iSkillEXP =  cs.hmcSkillEXP ;
                cs.iEDH = cs.hmcDmgToHumans;

                cs.iHPR =  cs.hmcHPRecovery;
                cs.iEvas =  cs.hmcEV;
                cs.iKBR =  cs.hmcKBRes ;
                cs.iSSFR =  cs.hmcSSFRes ;
                cs.iCastSpeed =  cs.hmcCastSpeed;
                cs.iVisionRange =  cs.hmcVisionRange;



                LoadItemEnch_cb();

            } //Helmet Magic Crystal - 1
            if (cs.sgn == 20)
            {
                if (SelectGear_cb.SelectedIndex <= 20)
                {
                    cmd.CommandText = "select * from [Helmet Magic Crystal] where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.hmc2Id = Convert.ToInt32(dr["Id"]);
                        cs.hmc2Type = Convert.ToString(dr["Type"]);
                        cs.hmc2DefMaxHP = Convert.ToInt32(dr["MaxHP"]);
                        cs.hmc2DefDR = 0;
                        cs.hmc2DefIgnoreAll = 0;
                        cs.hmc2DefAccuracy = 0;
                        cs.hmc2DefDmgToHumans = Convert.ToInt32(dr["DmgToHumans"]);
                        cs.hmc2DefDmgToDemi = 0;
                        cs.hmc2DefWeight = 0;
                        cs.hmc2DefAllRes = 0;
                        cs.hmc2DefMaxST = 0;
                        cs.hmc2DefLuck = 0;
                        cs.hmc2DefCombatEXP = Convert.ToInt32(dr["CombatEXP"]);
                        cs.hmc2DefSkillEXP = 0;

                        cs.hmc2DefHPRecovery = Convert.ToInt32(dr["HPRecovery"]);
                        cs.hmc2DefEV = Convert.ToInt32(dr["Evasion"]);
                        cs.hmc2DefKBRes = Convert.ToInt32(dr["KBRes"]);
                        cs.hmc2DefSSFRes = Convert.ToInt32(dr["SSFRes"]);
                        cs.hmc2DefCastSpeed = Convert.ToInt32(dr["CastSpeed"]);
                        cs.hmc2DefVisionRange = Convert.ToInt32(dr["VisionRange"]);



                    }
                }

                else
                {
                    cmd.CommandText = "select * from [Versatile Magic Crystal] where Id='" + (SelectGear_cb.SelectedIndex - 21).ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.hmc2Id = Convert.ToInt32(dr["Id"]);
                        cs.hmc2Type = Convert.ToString(dr["Type"]);
                        cs.hmc2DefIgnoreAll = Convert.ToInt32(dr["IgnoreAllRes"]);
                        cs.hmc2DefAccuracy = Convert.ToInt32(dr["Accuracy"]);
                        cs.hmc2DefDmgToHumans = Convert.ToInt32(dr["DamageToHumans"]);
                        cs.hmc2DefDmgToDemi = Convert.ToInt32(dr["DamageToDemi"]);
                        cs.hmc2DefWeight = Convert.ToInt32(dr["WeightLimit"]);
                        cs.hmc2DefAllRes = Convert.ToInt32(dr["AllRes"]);
                        cs.hmc2DefMaxHP = Convert.ToInt32(dr["MaxHP"]);
                        cs.hmc2DefMaxST = Convert.ToInt32(dr["MaxST"]);
                        cs.hmc2DefDR = Convert.ToInt32(dr["DR"]);
                        cs.hmc2DefLuck = Convert.ToInt32(dr["Luck"]);
                        cs.hmc2DefCombatEXP = Convert.ToInt32(dr["CombatEXP"]);
                        cs.hmc2DefSkillEXP = Convert.ToInt32(dr["SkillEXP"]);
                        cs.CrysH2SB = Convert.ToInt32(dr["SetBonus"]);


                        cs.hmc2DefHPRecovery = 0;
                        cs.hmc2DefEV = 0;
                        cs.hmc2DefKBRes = 0;
                        cs.hmc2DefSSFRes = 0;
                        cs.hmc2DefCastSpeed = 0;
                        cs.hmc2DefVisionRange = 0;
                    }
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = cs.hmc2Type + " Magic Crystal";
                Item_Icon_Load(cs.Type, cs.hmc2Id);
                CrysH2_btn.Background = new ImageBrush(Item_img.Source);
                cs.CrysH2();



                iAcc_n.Content = cs.hmc2Accuracy.ToString();
                iIgnoreResistance_n.Content = cs.hmc2IgnoreAll.ToString();
                iDR_n.Content = cs.hmc2DR.ToString();
                iHP_n.Content = cs.hmc2MaxHP.ToString();
                iRes_n.Content = cs.hmc2AllRes.ToString() + "%";
                iWeight_n.Content = cs.hmc2Weight.ToString();

                iADtDemiH_n.Content = cs.hmc2DmgToDemi.ToString();
                iST_n.Content = cs.hmc2MaxST.ToString();
                iLuck_n.Content = cs.hmc2Luck.ToString();
                iCombatEXP_n.Content = "+" + cs.hmc2CombatEXP.ToString() + "%";
                iSkillEXP_n.Content = "+" + cs.hmc2SkillEXP.ToString() + "%";
                iEDH_n.Content = cs.hmc2DmgToHumans.ToString();

                iHPR_n.Content = "+" + cs.hmc2HPRecovery;
                iEvas_n.Content = "+" + cs.hmc2EV;
                iKBR_n.Content = "+" + cs.hmc2KBRes + "%";
                iSSFR_n.Content = "+" + cs.hmc2SSFRes + "%";
                iCastSpeed_n.Content = "+" + cs.hmc2CastSpeed;
                iVisionRange_n.Content = "+" + cs.hmc2VisionRange + "m";


                cs.iAcc = cs.hmc2Accuracy;
                cs.iIgnoreResistance = cs.hmc2IgnoreAll;
                cs.iDR = cs.hmc2DR;
                cs.iHP = cs.hmc2MaxHP;
                cs.iRes = cs.hmc2AllRes ;
                cs.iWeight = cs.hmc2Weight;

                cs.iADtDemiH = cs.hmc2DmgToDemi;
                cs.iST = cs.hmc2MaxST;
                cs.iLuck = cs.hmc2Luck;
                cs.iCombatEXP =  cs.hmc2CombatEXP ;
                cs.iSkillEXP =  cs.hmc2SkillEXP ;
                cs.iEDH = cs.hmc2DmgToHumans;

                cs.iHPR =  cs.hmc2HPRecovery;
                cs.iEvas =  cs.hmc2EV;
                cs.iKBR =  cs.hmc2KBRes ;
                cs.iSSFR =  cs.hmc2SSFRes ;
                cs.iCastSpeed =  cs.hmc2CastSpeed;
                cs.iVisionRange =  cs.hmc2VisionRange;



                LoadItemEnch_cb();

            } //Helmet Magic Crystal - 2
            if (cs.sgn == 21)
            {
                if (SelectGear_cb.SelectedIndex <= 27)
                {
                    cmd.CommandText = "select * from [Armor Magic Crystal] where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.amcId = Convert.ToInt32(dr["Id"]);
                        cs.amcType = Convert.ToString(dr["Type"]);
                        cs.amcDefMaxHP = Convert.ToInt32(dr["MaxHP"]);
                        cs.amcDefDR = Convert.ToInt32(dr["DR"]);
                        cs.amcDefIgnoreAll = 0;
                        cs.amcDefAccuracy = 0;
                        cs.amcDefDmgToHumans = Convert.ToInt32(dr["DmgToHumans"]);
                        cs.amcDefDmgToDemi = 0;
                        cs.amcDefWeight = Convert.ToInt32(dr["WeightLimit"]);
                        cs.amcDefAllRes = Convert.ToInt32(dr["AllRes"]);
                        cs.amcDefMaxST = 0;
                        cs.amcDefLuck = 0;
                        cs.amcDefCombatEXP = 0;
                        cs.amcDefSkillEXP = 0;

                        cs.amcDefHPRecovery = Convert.ToInt32(dr["HPRecovery"]);
                        cs.amcDefSSFRes = Convert.ToInt32(dr["SSFRes"]);
                        cs.amcDefMaxMP = Convert.ToInt32(dr["MaxMP"]);
                        cs.amcDefMPRecovery = Convert.ToInt32(dr["MPRecovery"]);
                        cs.amcDefSpecialAtkEvRate = Convert.ToInt32(dr["SpecialAtkEvRate"]);
                        cs.amcDefMagicDR = Convert.ToInt32(dr["MagicDR"]);
                        cs.amcDefMelleDR = Convert.ToInt32(dr["MelleDR"]);
                        cs.amcDefRangeDR = Convert.ToInt32(dr["RangeDR"]);
                        cs.amcDefSiegeWeaponEvRate = Convert.ToInt32(dr["SiegeWeaponEvRate"]);





                    }
                }

                else
                {
                    cmd.CommandText = "select * from [Versatile Magic Crystal] where Id='" + (SelectGear_cb.SelectedIndex - 28).ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.amcId = Convert.ToInt32(dr["Id"]);
                        cs.amcType = Convert.ToString(dr["Type"]);
                        cs.amcDefIgnoreAll = Convert.ToInt32(dr["IgnoreAllRes"]);
                        cs.amcDefAccuracy = Convert.ToInt32(dr["Accuracy"]);
                        cs.amcDefDmgToHumans = Convert.ToInt32(dr["DamageToHumans"]);
                        cs.amcDefDmgToDemi = Convert.ToInt32(dr["DamageToDemi"]);
                        cs.amcDefWeight = Convert.ToInt32(dr["WeightLimit"]);
                        cs.amcDefAllRes = Convert.ToInt32(dr["AllRes"]);
                        cs.amcDefMaxHP = Convert.ToInt32(dr["MaxHP"]);
                        cs.amcDefMaxST = Convert.ToInt32(dr["MaxST"]);
                        cs.amcDefDR = Convert.ToInt32(dr["DR"]);
                        cs.amcDefLuck = Convert.ToInt32(dr["Luck"]);
                        cs.amcDefCombatEXP = Convert.ToInt32(dr["CombatEXP"]);
                        cs.amcDefSkillEXP = Convert.ToInt32(dr["SkillEXP"]);
                        cs.CrysA1SB = Convert.ToInt32(dr["SetBonus"]);


                        cs.amcDefHPRecovery = 0;
                        cs.amcDefSSFRes = 0;
                        cs.amcDefMaxMP = 0;
                        cs.amcDefMPRecovery = 0;
                        cs.amcDefSpecialAtkEvRate = 0;
                        cs.amcDefMagicDR = 0;
                        cs.amcDefMelleDR = 0;
                        cs.amcDefRangeDR = 0;
                        cs.amcDefSiegeWeaponEvRate = 0;

                    }
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = cs.amcType + " Magic Crystal";
                Item_Icon_Load(cs.Type, cs.amcId);
                CrysA1_btn.Background = new ImageBrush(Item_img.Source);
                cs.CrysA1();



                iAcc_n.Content = cs.amcAccuracy.ToString();
                iIgnoreResistance_n.Content = cs.amcIgnoreAll.ToString();
                iDR_n.Content = cs.amcDR.ToString();
                iHP_n.Content = cs.amcMaxHP.ToString();
                iRes_n.Content = cs.amcAllRes.ToString() + "%";
                iWeight_n.Content = cs.amcWeight.ToString();

                iADtDemiH_n.Content = cs.amcDmgToDemi.ToString();
                iST_n.Content = cs.amcMaxST.ToString();
                iLuck_n.Content = cs.amcLuck.ToString();
                iCombatEXP_n.Content = "+" + cs.amcCombatEXP.ToString() + "%";
                iSkillEXP_n.Content = "+" + cs.amcSkillEXP.ToString() + "%";
                iEDH_n.Content = cs.amcDmgToHumans.ToString();

                iHPR_n.Content = "+" + cs.amcHPRecovery;
                iSSFR_n.Content = "+" + cs.amcSSFRes + "%";
                iMPR_n.Content = "+" + cs.amcMPRecovery;
                iSpecialAttackEvRate_n.Content = "+" + cs.amcSpecialAtkEvRate + "%";
                iMagicDR_n.Content = "+" + cs.amcMagicDR;
                iMelleDR_n.Content = "+" + cs.amcMelleDR;
                iRangeDR_n.Content = "+" + cs.amcRangeDR;
                iSiegeWeaponEvRate_n.Content = "+" + cs.amcSiegeWeaponEvRate + "%";

                cs.iAcc = cs.amcAccuracy;
                cs.iIgnoreResistance = cs.amcIgnoreAll;
                cs.iDR = cs.amcDR;
                cs.iHP = cs.amcMaxHP;
                cs.iRes = cs.amcAllRes ;
                cs.iWeight = cs.amcWeight;

                cs.iADtDemiH = cs.amcDmgToDemi;
                cs.iST = cs.amcMaxST;
                cs.iLuck = cs.amcLuck;
                cs.iCombatEXP = cs.amcCombatEXP ;
                cs.iSkillEXP = cs.amcSkillEXP ;
                cs.iEDH = cs.amcDmgToHumans;

                cs.iHPR = cs.amcHPRecovery;
                cs.iSSFR = cs.amcSSFRes ;
                cs.iMPR = cs.amcMPRecovery;
                cs.iSpecialAttackEvRate = cs.amcSpecialAtkEvRate ;
                cs.iMagicDR = cs.amcMagicDR;
                cs.iMelleDR = cs.amcMelleDR;
                cs.iRangeDR = cs.amcRangeDR;
                cs.iSiegeWeaponEvRate = cs.amcSiegeWeaponEvRate ;




                LoadItemEnch_cb();

            } //Armor Magic Crystal - 1
            if (cs.sgn == 22)
            {
                if (SelectGear_cb.SelectedIndex <= 27)
                {
                    cmd.CommandText = "select * from [Armor Magic Crystal] where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.amc2Id = Convert.ToInt32(dr["Id"]);
                        cs.amc2Type = Convert.ToString(dr["Type"]);
                        cs.amc2DefMaxHP = Convert.ToInt32(dr["MaxHP"]);
                        cs.amc2DefDR = Convert.ToInt32(dr["DR"]);
                        cs.amc2DefIgnoreAll = 0;
                        cs.amc2DefAccuracy = 0;
                        cs.amc2DefDmgToHumans = Convert.ToInt32(dr["DmgToHumans"]);
                        cs.amc2DefDmgToDemi = 0;
                        cs.amc2DefWeight = Convert.ToInt32(dr["WeightLimit"]);
                        cs.amc2DefAllRes = Convert.ToInt32(dr["AllRes"]);
                        cs.amc2DefMaxST = 0;
                        cs.amc2DefLuck = 0;
                        cs.amc2DefCombatEXP = 0;
                        cs.amc2DefSkillEXP = 0;

                        cs.amc2DefHPRecovery = Convert.ToInt32(dr["HPRecovery"]);
                        cs.amc2DefSSFRes = Convert.ToInt32(dr["SSFRes"]);
                        cs.amc2DefMaxMP = Convert.ToInt32(dr["MaxMP"]);
                        cs.amc2DefMPRecovery = Convert.ToInt32(dr["MPRecovery"]);
                        cs.amc2DefSpecialAtkEvRate = Convert.ToInt32(dr["SpecialAtkEvRate"]);
                        cs.amc2DefMagicDR = Convert.ToInt32(dr["MagicDR"]);
                        cs.amc2DefMelleDR = Convert.ToInt32(dr["MelleDR"]);
                        cs.amc2DefRangeDR = Convert.ToInt32(dr["RangeDR"]);
                        cs.amc2DefSiegeWeaponEvRate = Convert.ToInt32(dr["SiegeWeaponEvRate"]);





                    }
                }

                else
                {
                    cmd.CommandText = "select * from [Versatile Magic Crystal] where Id='" + (SelectGear_cb.SelectedIndex - 28).ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.amc2Id = Convert.ToInt32(dr["Id"]);
                        cs.amc2Type = Convert.ToString(dr["Type"]);
                        cs.amc2DefIgnoreAll = Convert.ToInt32(dr["IgnoreAllRes"]);
                        cs.amc2DefAccuracy = Convert.ToInt32(dr["Accuracy"]);
                        cs.amc2DefDmgToHumans = Convert.ToInt32(dr["DamageToHumans"]);
                        cs.amc2DefDmgToDemi = Convert.ToInt32(dr["DamageToDemi"]);
                        cs.amc2DefWeight = Convert.ToInt32(dr["WeightLimit"]);
                        cs.amc2DefAllRes = Convert.ToInt32(dr["AllRes"]);
                        cs.amc2DefMaxHP = Convert.ToInt32(dr["MaxHP"]);
                        cs.amc2DefMaxST = Convert.ToInt32(dr["MaxST"]);
                        cs.amc2DefDR = Convert.ToInt32(dr["DR"]);
                        cs.amc2DefLuck = Convert.ToInt32(dr["Luck"]);
                        cs.amc2DefCombatEXP = Convert.ToInt32(dr["CombatEXP"]);
                        cs.amc2DefSkillEXP = Convert.ToInt32(dr["SkillEXP"]);
                        cs.CrysA2SB = Convert.ToInt32(dr["SetBonus"]);

                        cs.amc2DefHPRecovery = 0;
                        cs.amc2DefSSFRes = 0;
                        cs.amc2DefMaxMP = 0;
                        cs.amc2DefMPRecovery = 0;
                        cs.amc2DefSpecialAtkEvRate = 0;
                        cs.amc2DefMagicDR = 0;
                        cs.amc2DefMelleDR = 0;
                        cs.amc2DefRangeDR = 0;
                        cs.amc2DefSiegeWeaponEvRate = 0;

                    }
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = cs.amc2Type + " Magic Crystal";
                Item_Icon_Load(cs.Type, cs.amc2Id);
                CrysA2_btn.Background = new ImageBrush(Item_img.Source);
                cs.CrysA2();



                iAcc_n.Content = cs.amc2Accuracy.ToString();
                iIgnoreResistance_n.Content = cs.amc2IgnoreAll.ToString();
                iDR_n.Content = cs.amc2DR.ToString();
                iHP_n.Content = cs.amc2MaxHP.ToString();
                iRes_n.Content = cs.amc2AllRes.ToString() + "%";
                iWeight_n.Content = cs.amc2Weight.ToString();

                iADtDemiH_n.Content = cs.amc2DmgToDemi.ToString();
                iST_n.Content = cs.amc2MaxST.ToString();
                iLuck_n.Content = cs.amc2Luck.ToString();
                iCombatEXP_n.Content = "+" + cs.amc2CombatEXP.ToString() + "%";
                iSkillEXP_n.Content = "+" + cs.amc2SkillEXP.ToString() + "%";
                iEDH_n.Content = cs.amc2DmgToHumans.ToString();

                iHPR_n.Content = "+" + cs.amc2HPRecovery;
                iSSFR_n.Content = "+" + cs.amc2SSFRes + "%";
                iMPR_n.Content = "+" + cs.amc2MPRecovery;
                iSpecialAttackEvRate_n.Content = "+" + cs.amc2SpecialAtkEvRate + "%";
                iMagicDR_n.Content = "+" + cs.amc2MagicDR;
                iMelleDR_n.Content = "+" + cs.amc2MelleDR;
                iRangeDR_n.Content = "+" + cs.amc2RangeDR;
                iSiegeWeaponEvRate_n.Content = "+" + cs.amc2SiegeWeaponEvRate + "%";


                cs.iAcc = cs.amc2Accuracy;
                cs.iIgnoreResistance = cs.amc2IgnoreAll;
                cs.iDR = cs.amc2DR;
                cs.iHP = cs.amc2MaxHP;
                cs.iRes = cs.amc2AllRes ;
                cs.iWeight = cs.amc2Weight;

                cs.iADtDemiH = cs.amc2DmgToDemi;
                cs.iST = cs.amc2MaxST;
                cs.iLuck = cs.amc2Luck;
                cs.iCombatEXP = cs.amc2CombatEXP ;
                cs.iSkillEXP = cs.amc2SkillEXP ;
                cs.iEDH = cs.amc2DmgToHumans;

                cs.iHPR = cs.amc2HPRecovery;
                cs.iSSFR = cs.amc2SSFRes ;
                cs.iMPR = cs.amc2MPRecovery;
                cs.iSpecialAttackEvRate = cs.amc2SpecialAtkEvRate ;
                cs.iMagicDR = cs.amc2MagicDR;
                cs.iMelleDR = cs.amc2MelleDR;
                cs.iRangeDR = cs.amc2RangeDR;
                cs.iSiegeWeaponEvRate = cs.amc2SiegeWeaponEvRate ;




                LoadItemEnch_cb();

            } //Armor Magic Crystal - 2
            if (cs.sgn == 23)
            {
                if (SelectGear_cb.SelectedIndex <= 23)
                {
                    cmd.CommandText = "select * from [Gloves Magic Crystal] where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.gmcId = Convert.ToInt32(dr["Id"]);
                        cs.gmcType = Convert.ToString(dr["Type"]);
                        cs.gmcDefMaxHP = 0;
                        cs.gmcDefDR = 0;
                        cs.gmcDefIgnoreAll = 0;
                        cs.gmcDefAccuracy = Convert.ToInt32(dr["Accuracy"]);
                        cs.gmcDefDmgToHumans = Convert.ToInt32(dr["DmgToHumans"]);
                        cs.gmcDefDmgToDemi = 0;
                        cs.gmcDefWeight = Convert.ToInt32(dr["WeightLimit"]);
                        cs.gmcDefAllRes = 0;
                        cs.gmcDefMaxST = 0;
                        cs.gmcDefLuck = 0;
                        cs.gmcDefCombatEXP = 0;
                        cs.gmcDefSkillEXP = 0;

                        cs.gmcDefAtkSpeed = Convert.ToInt32(dr["AtkSpeed"]);
                        cs.gmcDefCastSpeed = Convert.ToInt32(dr["CastSpeed"]);
                        cs.gmcDefCrit = Convert.ToInt32(dr["Crit"]);
                        cs.gmcDefGrapRes = Convert.ToInt32(dr["GrapRes"]);
                        cs.gmcDefKFRes = Convert.ToInt32(dr["KFRes"]);
                        cs.gmcDefHidenAP = Convert.ToInt32(dr["HidenAP"]);
                        cs.gmcDefMelleAP = Convert.ToInt32(dr["MelleAP"]);
                        cs.gmcDefMagicAP = Convert.ToInt32(dr["MagicAP"]);
                        cs.gmcDefRangedAP = Convert.ToInt32(dr["RangedAP"]);






                    }
                }

                else
                {
                    cmd.CommandText = "select * from [Versatile Magic Crystal] where Id='" + (SelectGear_cb.SelectedIndex - 24).ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.gmcId = Convert.ToInt32(dr["Id"]);
                        cs.gmcType = Convert.ToString(dr["Type"]);
                        cs.gmcDefIgnoreAll = Convert.ToInt32(dr["IgnoreAllRes"]);
                        cs.gmcDefAccuracy = Convert.ToInt32(dr["Accuracy"]);
                        cs.gmcDefDmgToHumans = Convert.ToInt32(dr["DamageToHumans"]);
                        cs.gmcDefDmgToDemi = Convert.ToInt32(dr["DamageToDemi"]);
                        cs.gmcDefWeight = Convert.ToInt32(dr["WeightLimit"]);
                        cs.gmcDefAllRes = Convert.ToInt32(dr["AllRes"]);
                        cs.gmcDefMaxHP = Convert.ToInt32(dr["MaxHP"]);
                        cs.gmcDefMaxST = Convert.ToInt32(dr["MaxST"]);
                        cs.gmcDefDR = Convert.ToInt32(dr["DR"]);
                        cs.gmcDefLuck = Convert.ToInt32(dr["Luck"]);
                        cs.gmcDefCombatEXP = Convert.ToInt32(dr["CombatEXP"]);
                        cs.gmcDefSkillEXP = Convert.ToInt32(dr["SkillEXP"]);
                        cs.CrysG1SB = Convert.ToInt32(dr["SetBonus"]);

                        cs.gmcDefAtkSpeed = 0;
                        cs.gmcDefCastSpeed = 0;
                        cs.gmcDefCrit = 0;
                        cs.gmcDefGrapRes = 0;
                        cs.gmcDefKFRes = 0;
                        cs.gmcDefHidenAP = 0;
                        cs.gmcDefMelleAP = 0;
                        cs.gmcDefMagicAP = 0;
                        cs.gmcDefRangedAP = 0;

                    }
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = cs.gmcType + " Magic Crystal";
                Item_Icon_Load(cs.Type, cs.gmcId);
                CrysG1_btn.Background = new ImageBrush(Item_img.Source);
                cs.CrysG1();



                iAcc_n.Content = cs.gmcAccuracy.ToString();
                iIgnoreResistance_n.Content = cs.gmcIgnoreAll.ToString();
                iDR_n.Content = cs.gmcDR.ToString();
                iHP_n.Content = cs.gmcMaxHP.ToString();
                iRes_n.Content = cs.gmcAllRes.ToString() + "%";
                iWeight_n.Content = cs.gmcWeight.ToString();

                iADtDemiH_n.Content = cs.gmcDmgToDemi.ToString();
                iST_n.Content = cs.gmcMaxST.ToString();
                iLuck_n.Content = cs.gmcLuck.ToString();
                iCombatEXP_n.Content = "+" + cs.gmcCombatEXP.ToString() + "%";
                iSkillEXP_n.Content = "+" + cs.gmcSkillEXP.ToString() + "%";
                iEDH_n.Content = cs.gmcDmgToHumans.ToString();

                iAtkSpeed_n.Content = "+" + cs.gmcAtkSpeed;
                iCastSpeed_n.Content = "+" + cs.gmcCastSpeed;
                iCrit_n.Content = "+" + cs.gmcCrit;
                iGrapR_n.Content = "+" + cs.gmcGrapRes + "%";
                iKFR_n.Content = "+" + cs.gmcKFRes + "%";
                iHAP_n.Content = "+" + cs.gmcHidenAP;
                iMelleAP_n.Content = "+" + cs.gmcMelleAP;
                iMagicAP_n.Content = "+" + cs.gmcMagicAP;
                iRangeAP_n.Content = "+" + cs.gmcRangedAP;

               cs.iAcc = cs.gmcAccuracy;
                cs.iIgnoreResistance = cs.gmcIgnoreAll;
                cs.iDR = cs.gmcDR;
                cs.iHP = cs.gmcMaxHP;
                cs.iRes = cs.gmcAllRes ;
                cs.iWeight = cs.gmcWeight;

                cs.iADtDemiH = cs.gmcDmgToDemi;
                cs.iST = cs.gmcMaxST;
                cs.iLuck = cs.gmcLuck;
                cs.iCombatEXP = cs.gmcCombatEXP ;
                cs.iSkillEXP = cs.gmcSkillEXP ;
                cs.iEDH = cs.gmcDmgToHumans;

                cs.iAtkSpeed = cs.gmcAtkSpeed;
                cs.iCastSpeed = cs.gmcCastSpeed;
                cs.iCrit = cs.gmcCrit;
                cs.iGrapR = cs.gmcGrapRes ;
                cs.iKFR = cs.gmcKFRes ;
                cs.iHAP = cs.gmcHidenAP;
                cs.iMelleAP = cs.gmcMelleAP;
                cs.iMagicAP = cs.gmcMagicAP;
                cs.iRangeAP = cs.gmcRangedAP;




                LoadItemEnch_cb();

            } //Gloves Magic Crystal - 1
            if (cs.sgn == 24)
            {
                if (SelectGear_cb.SelectedIndex <= 23)
                {
                    cmd.CommandText = "select * from [Gloves Magic Crystal] where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.gmc2Id = Convert.ToInt32(dr["Id"]);
                        cs.gmc2Type = Convert.ToString(dr["Type"]);
                        cs.gmc2DefMaxHP = 0;
                        cs.gmc2DefDR = 0;
                        cs.gmc2DefIgnoreAll = 0;
                        cs.gmc2DefAccuracy = Convert.ToInt32(dr["Accuracy"]);
                        cs.gmc2DefDmgToHumans = Convert.ToInt32(dr["DmgToHumans"]);
                        cs.gmc2DefDmgToDemi = 0;
                        cs.gmc2DefWeight = Convert.ToInt32(dr["WeightLimit"]);
                        cs.gmc2DefAllRes = 0;
                        cs.gmc2DefMaxST = 0;
                        cs.gmc2DefLuck = 0;
                        cs.gmc2DefCombatEXP = 0;
                        cs.gmc2DefSkillEXP = 0;

                        cs.gmc2DefAtkSpeed = Convert.ToInt32(dr["AtkSpeed"]);
                        cs.gmc2DefCastSpeed = Convert.ToInt32(dr["CastSpeed"]);
                        cs.gmc2DefCrit = Convert.ToInt32(dr["Crit"]);
                        cs.gmc2DefGrapRes = Convert.ToInt32(dr["GrapRes"]);
                        cs.gmc2DefKFRes = Convert.ToInt32(dr["KFRes"]);
                        cs.gmc2DefHidenAP = Convert.ToInt32(dr["HidenAP"]);
                        cs.gmc2DefMelleAP = Convert.ToInt32(dr["MelleAP"]);
                        cs.gmc2DefMagicAP = Convert.ToInt32(dr["MagicAP"]);
                        cs.gmc2DefRangedAP = Convert.ToInt32(dr["RangedAP"]);






                    }
                }

                else
                {
                    cmd.CommandText = "select * from [Versatile Magic Crystal] where Id='" + (SelectGear_cb.SelectedIndex - 24).ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.gmc2Id = Convert.ToInt32(dr["Id"]);
                        cs.gmc2Type = Convert.ToString(dr["Type"]);
                        cs.gmc2DefIgnoreAll = Convert.ToInt32(dr["IgnoreAllRes"]);
                        cs.gmc2DefAccuracy = Convert.ToInt32(dr["Accuracy"]);
                        cs.gmc2DefDmgToHumans = Convert.ToInt32(dr["DamageToHumans"]);
                        cs.gmc2DefDmgToDemi = Convert.ToInt32(dr["DamageToDemi"]);
                        cs.gmc2DefWeight = Convert.ToInt32(dr["WeightLimit"]);
                        cs.gmc2DefAllRes = Convert.ToInt32(dr["AllRes"]);
                        cs.gmc2DefMaxHP = Convert.ToInt32(dr["MaxHP"]);
                        cs.gmc2DefMaxST = Convert.ToInt32(dr["MaxST"]);
                        cs.gmc2DefDR = Convert.ToInt32(dr["DR"]);
                        cs.gmc2DefLuck = Convert.ToInt32(dr["Luck"]);
                        cs.gmc2DefCombatEXP = Convert.ToInt32(dr["CombatEXP"]);
                        cs.gmc2DefSkillEXP = Convert.ToInt32(dr["SkillEXP"]);
                        cs.CrysG2SB = Convert.ToInt32(dr["SetBonus"]);

                        cs.gmc2DefAtkSpeed = 0;
                        cs.gmc2DefCastSpeed = 0;
                        cs.gmc2DefCrit = 0;
                        cs.gmc2DefGrapRes = 0;
                        cs.gmc2DefKFRes = 0;
                        cs.gmc2DefHidenAP = 0;
                        cs.gmc2DefMelleAP = 0;
                        cs.gmc2DefMagicAP = 0;
                        cs.gmc2DefRangedAP = 0;

                    }
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = cs.gmc2Type + " Magic Crystal";
                Item_Icon_Load(cs.Type, cs.gmc2Id);
                CrysG2_btn.Background = new ImageBrush(Item_img.Source);
                cs.CrysG2();



                iAcc_n.Content = cs.gmc2Accuracy.ToString();
                iIgnoreResistance_n.Content = cs.gmc2IgnoreAll.ToString();
                iDR_n.Content = cs.gmc2DR.ToString();
                iHP_n.Content = cs.gmc2MaxHP.ToString();
                iRes_n.Content = cs.gmc2AllRes.ToString() + "%";
                iWeight_n.Content = cs.gmc2Weight.ToString();

                iADtDemiH_n.Content = cs.gmc2DmgToDemi.ToString();
                iST_n.Content = cs.gmc2MaxST.ToString();
                iLuck_n.Content = cs.gmc2Luck.ToString();
                iCombatEXP_n.Content = "+" + cs.gmc2CombatEXP.ToString() + "%";
                iSkillEXP_n.Content = "+" + cs.gmc2SkillEXP.ToString() + "%";
                iEDH_n.Content = cs.gmc2DmgToHumans.ToString();

                iAtkSpeed_n.Content = "+" + cs.gmc2AtkSpeed;
                iCastSpeed_n.Content = "+" + cs.gmc2CastSpeed;
                iCrit_n.Content = "+" + cs.gmc2Crit;
                iGrapR_n.Content = "+" + cs.gmc2GrapRes + "%";
                iKFR_n.Content = "+" + cs.gmc2KFRes + "%";
                iHAP_n.Content = "+" + cs.gmc2HidenAP;
                iMelleAP_n.Content = "+" + cs.gmc2MelleAP;
                iMagicAP_n.Content = "+" + cs.gmc2MagicAP;
                iRangeAP_n.Content = "+" + cs.gmc2RangedAP;

                cs.iAcc = cs.gmc2Accuracy;
                cs.iIgnoreResistance = cs.gmc2IgnoreAll;
                cs.iDR = cs.gmc2DR;
                cs.iHP = cs.gmc2MaxHP;
                cs.iRes = cs.gmc2AllRes ;
                cs.iWeight = cs.gmc2Weight;

                cs.iADtDemiH = cs.gmc2DmgToDemi;
                cs.iST = cs.gmc2MaxST;
                cs.iLuck = cs.gmc2Luck;
                cs.iCombatEXP = cs.gmc2CombatEXP ;
                cs.iSkillEXP = cs.gmc2SkillEXP ;
                cs.iEDH = cs.gmc2DmgToHumans;

                cs.iAtkSpeed = cs.gmc2AtkSpeed;
                cs.iCastSpeed = cs.gmc2CastSpeed;
                cs.iCrit = cs.gmc2Crit;
                cs.iGrapR = cs.gmc2GrapRes ;
                cs.iKFR = cs.gmc2KFRes ;
                cs.iHAP = cs.gmc2HidenAP;
                cs.iMelleAP = cs.gmc2MelleAP;
                cs.iMagicAP = cs.gmc2MagicAP;
                cs.iRangeAP = cs.gmc2RangedAP;




                LoadItemEnch_cb();

            } //Gloves Magic Crystal - 2
            if (cs.sgn == 25)
            {
                if (SelectGear_cb.SelectedIndex <= 24)
                {
                    cmd.CommandText = "select * from [Shoes Magic Crystal] where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.smcId = Convert.ToInt32(dr["Id"]);
                        cs.smcType = Convert.ToString(dr["Type"]);
                        cs.smcDefMaxHP = 0;
                        cs.smcDefDR = 0;
                        cs.smcDefIgnoreAll = 0;
                        cs.smcDefAccuracy = 0;
                        cs.smcDefDmgToHumans = Convert.ToInt32(dr["DmgToHum"]);
                        cs.smcDefDmgToDemi = 0;
                        cs.smcDefWeight = Convert.ToInt32(dr["WeightLimit"]);
                        cs.smcDefAllRes = 0;
                        cs.smcDefMaxST = Convert.ToInt32(dr["MaxST"]);
                        cs.smcDefLuck = 0;
                        cs.smcDefCombatEXP = 0;
                        cs.smcDefSkillEXP = 0;


                        cs.smcDefKFRes = Convert.ToInt32(dr["KFRes"]);
                        cs.smcDefKBRes = Convert.ToInt32(dr["KBRes"]);
                        cs.smcDefSSFRes = Convert.ToInt32(dr["SSFRes"]);
                        cs.smcDefMVSpeed = Convert.ToInt32(dr["MVSpeed"]);
                        cs.smcDefJump = Convert.ToInt32(dr["Jump"]);
                        cs.smcDefFallDamage = Convert.ToInt32(dr["FallDmg"]);
                        cs.smcDefUnderWaterBreath = Convert.ToInt32(dr["UnderwaterBreath"]);
                        cs.smcDefMaxEnergy = Convert.ToInt32(dr["MaxEnergy"]);
                    }
                }

                else
                {
                    cmd.CommandText = "select * from [Versatile Magic Crystal] where Id='" + (SelectGear_cb.SelectedIndex - 25).ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.smcId = Convert.ToInt32(dr["Id"]);
                        cs.smcType = Convert.ToString(dr["Type"]);
                        cs.smcDefIgnoreAll = Convert.ToInt32(dr["IgnoreAllRes"]);
                        cs.smcDefAccuracy = Convert.ToInt32(dr["Accuracy"]);
                        cs.smcDefDmgToHumans = Convert.ToInt32(dr["DamageToHumans"]);
                        cs.smcDefDmgToDemi = Convert.ToInt32(dr["DamageToDemi"]);
                        cs.smcDefWeight = Convert.ToInt32(dr["WeightLimit"]);
                        cs.smcDefAllRes = Convert.ToInt32(dr["AllRes"]);
                        cs.smcDefMaxHP = Convert.ToInt32(dr["MaxHP"]);
                        cs.smcDefMaxST = Convert.ToInt32(dr["MaxST"]);
                        cs.smcDefDR = Convert.ToInt32(dr["DR"]);
                        cs.smcDefLuck = Convert.ToInt32(dr["Luck"]);
                        cs.smcDefCombatEXP = Convert.ToInt32(dr["CombatEXP"]);
                        cs.smcDefSkillEXP = Convert.ToInt32(dr["SkillEXP"]);
                        cs.CrysB1SB = Convert.ToInt32(dr["SetBonus"]);

                        cs.smcDefKFRes = 0;
                        cs.smcDefKBRes = 0;
                        cs.smcDefSSFRes = 0;
                        cs.smcDefMVSpeed = 0;
                        cs.smcDefJump = 0;
                        cs.smcDefFallDamage = 0;
                        cs.smcDefUnderWaterBreath = 0;
                        cs.smcDefMaxEnergy = 0;
                    }
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = cs.smcType + " Magic Crystal";
                Item_Icon_Load(cs.Type, cs.smcId);
                CrysB1_btn.Background = new ImageBrush(Item_img.Source);
                cs.CrysS1();

                iAcc_n.Content = cs.smcAccuracy.ToString();
                iIgnoreResistance_n.Content = cs.smcIgnoreAll.ToString();
                iDR_n.Content = cs.smcDR.ToString();
                iHP_n.Content = cs.smcMaxHP.ToString();
                iRes_n.Content = cs.smcAllRes.ToString() + "%";
                iWeight_n.Content = cs.smcWeight.ToString();

                iADtDemiH_n.Content = cs.smcDmgToDemi.ToString();
                iST_n.Content = cs.smcMaxST.ToString();
                iLuck_n.Content = cs.smcLuck.ToString();
                iCombatEXP_n.Content = "+" + cs.smcCombatEXP.ToString() + "%";
                iSkillEXP_n.Content = "+" + cs.smcSkillEXP.ToString() + "%";
                iEDH_n.Content = cs.smcDmgToHumans.ToString();


                iKFR_n.Content = "+" + cs.smcKFRes + "%";
                iKBR_n.Content = "+" + cs.smcKBRes + "%";
                iSSFR_n.Content = "+" + cs.smcSSFRes + "%";
                iJump_n.Content = "+" + cs.smcJump + "%";
                iFallDamage_n.Content = cs.smcFallDamage + "%";
                iUnderwaterBreath_n.Content = "+" + cs.smcUnderWaterBreath + " sec";
                iMaxEnergy_n.Content = "+" + cs.smcMaxEnergy;
                iMVS_n.Content = "+" + cs.smcMVSpeed;

                cs.iAcc = cs.smcAccuracy;
                cs.iIgnoreResistance = cs.smcIgnoreAll;
                cs.iDR = cs.smcDR;
                cs.iHP = cs.smcMaxHP;
                cs.iRes = cs.smcAllRes ;
                cs.iWeight = cs.smcWeight;

                cs.iADtDemiH = cs.smcDmgToDemi;
                cs.iST = cs.smcMaxST;
                cs.iLuck = cs.smcLuck;
                cs.iCombatEXP = cs.smcCombatEXP ;
                cs.iSkillEXP = cs.smcSkillEXP ;
                cs.iEDH = cs.smcDmgToHumans;


                cs.iKFR = cs.smcKFRes ;
                cs.iKBR = cs.smcKBRes ;
                cs.iSSFR = cs.smcSSFRes ;
                cs.iJump = cs.smcJump ;
                cs.iFallDamage = cs.smcFallDamage ;
                cs.iUnderwaterBreath = cs.smcUnderWaterBreath;
                cs.iMaxEnergy = cs.smcMaxEnergy;
                cs.iMVS = cs.smcMVSpeed;


                LoadItemEnch_cb();

            } //Shoes Magic Crystal - 1
            if (cs.sgn == 26)
            {
                if (SelectGear_cb.SelectedIndex <= 24)
                {
                    cmd.CommandText = "select * from [Shoes Magic Crystal] where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.smc2Id = Convert.ToInt32(dr["Id"]);
                        cs.smc2Type = Convert.ToString(dr["Type"]);
                        cs.smc2DefMaxHP = 0;
                        cs.smc2DefDR = 0;
                        cs.smc2DefIgnoreAll = 0;
                        cs.smc2DefAccuracy = 0;
                        cs.smc2DefDmgToHumans = Convert.ToInt32(dr["DmgToHum"]);
                        cs.smc2DefDmgToDemi = 0;
                        cs.smc2DefWeight = Convert.ToInt32(dr["WeightLimit"]);
                        cs.smc2DefAllRes = 0;
                        cs.smc2DefMaxST = Convert.ToInt32(dr["MaxST"]);
                        cs.smc2DefLuck = 0;
                        cs.smc2DefCombatEXP = 0;
                        cs.smc2DefSkillEXP = 0;


                        cs.smc2DefKFRes = Convert.ToInt32(dr["KFRes"]);
                        cs.smc2DefKBRes = Convert.ToInt32(dr["KBRes"]);
                        cs.smc2DefSSFRes = Convert.ToInt32(dr["SSFRes"]);
                        cs.smc2DefMVSpeed = Convert.ToInt32(dr["MVSpeed"]);
                        cs.smc2DefJump = Convert.ToInt32(dr["Jump"]);
                        cs.smc2DefFallDamage = Convert.ToInt32(dr["FallDmg"]);
                        cs.smc2DefUnderWaterBreath = Convert.ToInt32(dr["UnderwaterBreath"]);
                        cs.smc2DefMaxEnergy = Convert.ToInt32(dr["MaxEnergy"]);







                    }
                }

                else
                {
                    cmd.CommandText = "select * from [Versatile Magic Crystal] where Id='" + (SelectGear_cb.SelectedIndex - 25).ToString() + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        cs.smc2Id = Convert.ToInt32(dr["Id"]);
                        cs.smc2Type = Convert.ToString(dr["Type"]);
                        cs.smc2DefIgnoreAll = Convert.ToInt32(dr["IgnoreAllRes"]);
                        cs.smc2DefAccuracy = Convert.ToInt32(dr["Accuracy"]);
                        cs.smc2DefDmgToHumans = Convert.ToInt32(dr["DamageToHumans"]);
                        cs.smc2DefDmgToDemi = Convert.ToInt32(dr["DamageToDemi"]);
                        cs.smc2DefWeight = Convert.ToInt32(dr["WeightLimit"]);
                        cs.smc2DefAllRes = Convert.ToInt32(dr["AllRes"]);
                        cs.smc2DefMaxHP = Convert.ToInt32(dr["MaxHP"]);
                        cs.smc2DefMaxST = Convert.ToInt32(dr["MaxST"]);
                        cs.smc2DefDR = Convert.ToInt32(dr["DR"]);
                        cs.smc2DefLuck = Convert.ToInt32(dr["Luck"]);
                        cs.smc2DefCombatEXP = Convert.ToInt32(dr["CombatEXP"]);
                        cs.smc2DefSkillEXP = Convert.ToInt32(dr["SkillEXP"]);
                        cs.CrysB2SB = Convert.ToInt32(dr["SetBonus"]);

                        cs.smc2DefKFRes = 0;
                        cs.smc2DefKBRes = 0;
                        cs.smc2DefSSFRes = 0;
                        cs.smc2DefMVSpeed = 0;
                        cs.smc2DefJump = 0;
                        cs.smc2DefFallDamage = 0;
                        cs.smc2DefUnderWaterBreath = 0;
                        cs.smc2DefMaxEnergy = 0;


                    }
                }

                LoadItemEnch_cb();
                LoadItemCaph_cb();

                cs.Type = cs.smc2Type + " Magic Crystal";
                Item_Icon_Load(cs.Type, cs.smc2Id);
                CrysB2_btn.Background = new ImageBrush(Item_img.Source);
                cs.CrysS2();



                iAcc_n.Content = cs.smc2Accuracy.ToString();
                iIgnoreResistance_n.Content = cs.smc2IgnoreAll.ToString();
                iDR_n.Content = cs.smc2DR.ToString();
                iHP_n.Content = cs.smc2MaxHP.ToString();
                iRes_n.Content = cs.smc2AllRes.ToString() + "%";
                iWeight_n.Content = cs.smc2Weight.ToString();

                iADtDemiH_n.Content = cs.smc2DmgToDemi.ToString();
                iST_n.Content = cs.smc2MaxST.ToString();
                iLuck_n.Content = cs.smc2Luck.ToString();
                iCombatEXP_n.Content = "+" + cs.smc2CombatEXP.ToString() + "%";
                iSkillEXP_n.Content = "+" + cs.smc2SkillEXP.ToString() + "%";
                iEDH_n.Content = cs.smc2DmgToHumans.ToString();


                iKFR_n.Content = "+" + cs.smc2KFRes + "%";
                iKBR_n.Content = "+" + cs.smc2KBRes + "%";
                iSSFR_n.Content = "+" + cs.smc2SSFRes + "%";
                iJump_n.Content = "+" + cs.smc2Jump + "%";
                iFallDamage_n.Content = cs.smc2FallDamage + "%";
                iUnderwaterBreath_n.Content = "+" + cs.smc2UnderWaterBreath + " sec";
                iMaxEnergy_n.Content = "+" + cs.smc2MaxEnergy;
                iMVS_n.Content = "+" + cs.smc2MVSpeed;


                cs.iAcc = cs.smc2Accuracy;
                cs.iIgnoreResistance = cs.smc2IgnoreAll;
                cs.iDR = cs.smc2DR;
                cs.iHP = cs.smc2MaxHP;
                cs.iRes = cs.smc2AllRes;
                cs.iWeight = cs.smc2Weight;

                cs.iADtDemiH = cs.smc2DmgToDemi;
                cs.iST = cs.smc2MaxST;
                cs.iLuck = cs.smc2Luck;
                cs.iCombatEXP = cs.smc2CombatEXP;
                cs.iSkillEXP = cs.smc2SkillEXP;
                cs.iEDH = cs.smc2DmgToHumans;


                cs.iKFR = cs.smc2KFRes;
                cs.iKBR = cs.smc2KBRes;
                cs.iSSFR = cs.smc2SSFRes;
                cs.iJump = cs.smc2Jump;
                cs.iFallDamage = cs.smc2FallDamage;
                cs.iUnderwaterBreath = cs.smc2UnderWaterBreath;
                cs.iMaxEnergy = cs.smc2MaxEnergy;
                cs.iMVS = cs.smc2MVSpeed;



                LoadItemEnch_cb();

            } //Shoes Magic Crystal - 2
            //SetBonus
            cs.BossSetBonusCheck();
            cs.AccSetBonusCheck();
            cs.WeaponSetBonusCheck();
            cs.CrysSetBonusCheck();
            cs.BossSetBonus();
            cs.AccSetBonus();
            cs.WeaponSetBonus();
            cs.CrysSetBonus();
            cs.GearScoreBonus();
            MainStateLabels();
            AbilitiesLabels();
            OffenceStateLabels();
            SurvivalStateLabels();
            BonusStateLabels();
            DefenceStateLabels();
            ProffessionStateLabels();
            AdditionalStateLabels();
            OtherStateLabels();
            ItemStateLabels();
            ResistanceStateLabels();
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
                ItemCaph_cb.Visibility = Visibility.Hidden;
                Caph_lbl.Visibility = Visibility.Hidden;
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

                cs.iAP = cs.beltap;
                cs.iDP = cs.beltdp;
                cs.iEvas = cs.beltev;
                cs.iAcc = cs.beltacc;
                cs.iRes = cs.beltResis;
                cs.iDR = cs.beltDR;
                cs.iHP = cs.beltHP;
                cs.iWeight = cs.beltWeight;
                cs.iSpiritRage = cs.beltSpiritRage;
                cs.iEAPa = cs.beltAPagaingst;

                if (ItemEnch_cb.SelectedIndex == 0) { Belt_btn.Content = ""; }
                else if (cs.beltEnch == false) Belt_btn.Content = "";
                else Belt_btn.Content = ItemEnch_cb.SelectedValue;

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

                cs.iAP = cs.neckap;
                cs.iDP = cs.neckdp;
                cs.iEvas = cs.neckev;
                cs.iAcc = cs.neckacc;
                cs.iRes = cs.neckAllRes;
                cs.iDR = cs.neckDR;
                cs.iSSFR = cs.neckSSF;
                cs.iKBR = cs.neckKB;
                cs.iGrapR = cs.neckG;
                cs.iKFR = cs.neckKF;
                cs.iHP = cs.neckHP;
                cs.iSpiritRage = cs.neckSpiritRage;
                cs.iEAPa = cs.neckAPagaingst;
                cs.iExtraDamKama = cs.neckKamaDamage;
                cs.iEDtoBack = cs.neckBackDamage;

                if (ItemEnch_cb.SelectedIndex == 0) { Necklace_btn.Content = ""; }
                else { Necklace_btn.Content = ItemEnch_cb.SelectedValue; }

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

                cs.iAP = cs.ring1ap;
                cs.iDP = cs.ring1dp;
                cs.iEvas = cs.ring1ev;
                cs.iAcc = cs.ring1acc;
                cs.iDR = cs.ring1DR;
                cs.iHP = cs.ring1HP;
                cs.iMP = cs.ring1MP;
                cs.iST = cs.ring1ST;
                cs.iHEV = cs.ring1HEv;
                cs.iEAPa = cs.ring1APagaingst;
                cs.iExtraDamKama = cs.ring1KamaDamage;
                cs.iEDH = cs.ring1DamageHumans;
                cs.iADtDemiH = cs.ring1DamageDemihumans;
                cs.iEDtAExcHumanAndDemi = cs.ring1DamageAllExcept;
                cs.iBidding = cs.ring1Bidding;
                cs.iSpiritRage = cs.ring1SpiritRage;

                if (ItemEnch_cb.SelectedIndex == 0) { Ring1_btn.Content = ""; }
                else { Ring1_btn.Content = ItemEnch_cb.SelectedValue; }

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


                cs.iAP = cs.ring2ap;
                cs.iDP = cs.ring2dp;
                cs.iEvas = cs.ring2ev;
                cs.iAcc = cs.ring2acc;
                cs.iDR = cs.ring2DR;
                cs.iHP = cs.ring2HP;
                cs.iMP = cs.ring2MP;
                cs.iST = cs.ring2ST;
                cs.iHEV = cs.ring2HEv;
                cs.iEAPa = cs.ring2APagaingst;
                cs.iExtraDamKama = cs.ring2KamaDamage;
                cs.iEDH = cs.ring2DamageHumans;
                cs.iADtDemiH = cs.ring2DamageDemihumans;
                cs.iEDtAExcHumanAndDemi = cs.ring2DamageAllExcept;
                cs.iBidding = cs.ring2Bidding;
                cs.iSpiritRage = cs.ring2SpiritRage;

                if (ItemEnch_cb.SelectedIndex == 0) { Ring2_btn.Content = ""; }
                else { Ring2_btn.Content = ItemEnch_cb.SelectedValue; }

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

                cs.iAP = cs.ear1ap;
                cs.iDP = cs.ear1dp;
                cs.iEvas = cs.ear1ev;
                cs.iAcc = cs.ear1acc;
                cs.iDR = cs.ear1DR;
                cs.iHP = cs.ear1HP;
                cs.iMP = cs.ear1MP;
                cs.iST = cs.ear1ST;
                cs.iSpiritRage = cs.ear1SpiritRage;
                cs.iEAPa = cs.ear1APagaingst;
                cs.iExtraDamKama = cs.ear1KamaDamage;

                if (ItemEnch_cb.SelectedIndex == 0) { Earring1_btn.Content = ""; }
                else { Earring1_btn.Content = ItemEnch_cb.SelectedValue; }

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

                cs.iAP = cs.ear2ap;
                cs.iDP = cs.ear2dp;
                cs.iEvas = cs.ear2ev;
                cs.iAcc = cs.ear2acc;
                cs.iDR = cs.ear2DR;
                cs.iHP = cs.ear2HP;
                cs.iMP = cs.ear2MP;
                cs.iST = cs.ear2ST;
                cs.iSpiritRage = cs.ear2SpiritRage;
                cs.iEAPa = cs.ear2APagaingst;
                cs.iExtraDamKama = cs.ear2KamaDamage;

                if (ItemEnch_cb.SelectedIndex == 0) { Earring2_btn.Content = ""; }
                else { Earring2_btn.Content = ItemEnch_cb.SelectedValue; }

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

                cs.iDP = cs.armdp;
                cs.iEvas = cs.armev;
                cs.iHEV = cs.armhev;
                cs.iDR = cs.armdr;
                cs.iHDR = cs.armhdr;
                cs.iHP = cs.armHP;
                cs.iMP = cs.armMP;
                cs.iSSFR = cs.armSSFRes;
                cs.iWeight = cs.armWeight;
                cs.iAcc = cs.armAcc;
                cs.iHPR = cs.armHPRecovery;
                cs.iMPR = cs.armMPRecovery;

                if (ItemEnch_cb.SelectedIndex == 0) { Armour_btn.Content = ""; }
                else if (ItemEnch_cb.SelectedIndex >= 1 & ItemEnch_cb.SelectedIndex <= 15) { Armour_btn.Content = "+" + ItemEnch_cb.SelectedValue; }
                else Armour_btn.Content = ItemEnch_cb.SelectedValue;

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

                cs.iDP = cs.heldp;
                cs.iEvas = cs.helev;
                cs.iHEV = cs.helhev;
                cs.iDR = cs.heldr;
                cs.iHDR = cs.helhdr;
                cs.iHP = cs.helHP;
                cs.iSSFR = cs.helSSFRes;
                cs.iKBR = cs.helKBRes;
                cs.iGrapR = cs.helGrapleRes;
                cs.iKFR = cs.helKFRes;
                cs.iST = cs.helST;
                cs.iWeight = cs.helWeight;
                cs.iHPR = cs.helHPRecovery;
                cs.iLuck = cs.helLuck;

                if (ItemEnch_cb.SelectedIndex == 0) { Helmet_btn.Content = ""; }
                else if (ItemEnch_cb.SelectedIndex >= 1 & ItemEnch_cb.SelectedIndex <= 15) { Helmet_btn.Content = "+" + ItemEnch_cb.SelectedValue; }
                else Helmet_btn.Content = ItemEnch_cb.SelectedValue;
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

                cs.iDP = cs.glovdp;
                cs.iEvas = cs.glovev;
                cs.iHEV = cs.glovhev;
                cs.iDR = cs.glovdr;
                cs.iHDR = cs.glovhdr;
                cs.iAcc = cs.glovacc;
                cs.iGrapR = cs.glovGrapleRes;
                cs.iAtkSpeed = cs.glovAtkSpeed;
                cs.iCastSpeed = cs.glovCastSpeed;
                cs.iCrit = cs.glovCrit;
                cs.iWeight = cs.glovWeight;
                cs.iEDtA = cs.glovDamage;

                if (ItemEnch_cb.SelectedIndex == 0) { Gloves_btn.Content = ""; }
                else if (ItemEnch_cb.SelectedIndex >= 1 & ItemEnch_cb.SelectedIndex <= 15) { Gloves_btn.Content = "+" + ItemEnch_cb.SelectedValue; }
                else Gloves_btn.Content = ItemEnch_cb.SelectedValue;

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

                cs.iDP = cs.shdp;
                cs.iEvas = cs.shev;
                cs.iHEV = cs.shhev;
                cs.iDR = cs.shdr;
                cs.iHDR = cs.shhdr;
                cs.iKBR = cs.shKBRes;
                cs.iMVS = cs.shMvs;
                cs.iST = cs.shMaxST;
                cs.iWeight = cs.shWeight;

                if (ItemEnch_cb.SelectedIndex == 0) { Boots_btn.Content = ""; }
                else if (ItemEnch_cb.SelectedIndex >= 1 & ItemEnch_cb.SelectedIndex <= 15) { Boots_btn.Content = "+" + ItemEnch_cb.SelectedValue; }
                else Boots_btn.Content = ItemEnch_cb.SelectedValue;

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

                iAAP_n.Content = cs.awkAPlow.ToString() + '~' + cs.awkAPhigh.ToString();
                iAcc_n.Content = cs.awkAccuracy.ToString();
                iEDH_n.Content = cs.awkDamageHumans.ToString();
                iEDtA_n.Content = cs.awkDamageAll.ToString();
                iEAPa_n.Content = cs.awkAPagainst.ToString();

                cs.iAAP = (cs.awkAPlow + cs.awkAPhigh) / 2;
                cs.iAcc = cs.awkAccuracy;
                cs.iEDH = cs.awkDamageHumans;
                cs.iEDtA = cs.awkDamageAll;
                cs.iEAPa = cs.awkAPagainst;

                if (ItemEnch_cb.SelectedIndex == 0) { AW_btn.Content = ""; }
                else if (ItemEnch_cb.SelectedIndex >= 1 & ItemEnch_cb.SelectedIndex <= 15) { AW_btn.Content = "+" + ItemEnch_cb.SelectedValue; }
                else AW_btn.Content = ItemEnch_cb.SelectedValue;

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

                cs.iAP = (cs.mwAPlow + cs.mwAPhigh) / 2;
                cs.iAcc = cs.mwAccuracy;
                cs.iEDH = cs.mwDamageHumans;
                cs.iEDtA = cs.mwDamageAll;
                cs.iEAPa = cs.mwAPagainst;
                cs.iADtDemiH = cs.mwDamDemi;
                cs.iAtkSpeed = cs.mwAtkSpeed;
                cs.iCastSpeed = cs.mwCastSpeed;
                cs.iCrit = cs.mwCrit;
                cs.iHPRecoveryChance = cs.mwRecoveryChance;
                cs.iIgnoreResistance = cs.mwIgnore;

                if (ItemEnch_cb.SelectedIndex == 0) { MW_btn.Content = ""; }
                else if (ItemEnch_cb.SelectedIndex >= 1 & ItemEnch_cb.SelectedIndex <= 15) { MW_btn.Content = "+" + ItemEnch_cb.SelectedValue; }
                else MW_btn.Content = ItemEnch_cb.SelectedValue;

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


                cs.iAP = (cs.swAPlow + cs.swAPhigh) / 2;
                cs.iAcc = cs.swAccuracy;
                cs.iEAPa = cs.swAPagainst;
                cs.iIgnoreResistance = cs.swIgnore;
                cs.iDP = cs.swDP;
                cs.iEvas = cs.swEvasion;
                cs.iHEV = cs.swHEvasion;
                cs.iDR = cs.swDR;
                cs.iHP = cs.swMaxHP;
                cs.iMP = cs.swMaxMP;
                cs.iST = cs.swMaxST;
                cs.iRes = cs.swAllRes;
                cs.iST = cs.swMaxST;
                cs.iHAP = cs.swHidenAP;
                cs.iSpecialAttackED = cs.swSpecialAttackDam;
                cs.iSpecialAttackEvRate = cs.swSpecialAttackEv;


                if (ItemEnch_cb.SelectedIndex == 0) { SW_btn.Content = ""; }
                else if (cs.swEnch == false) SW_btn.Content = "";
                else if (ItemEnch_cb.SelectedIndex >= 1 & ItemEnch_cb.SelectedIndex <= 15) { SW_btn.Content = "+" + ItemEnch_cb.SelectedValue; }
                else SW_btn.Content = ItemEnch_cb.SelectedValue;

                FillCharacterState();
            } //Sub-Weapons
            LoadItemCaph_cb();
            cs.GearScoreBonus();
            MainStateLabels();
            AbilitiesLabels();
            OffenceStateLabels();
            SurvivalStateLabels();
            BonusStateLabels();
            DefenceStateLabels();
            ProffessionStateLabels();
            AdditionalStateLabels();
            OtherStateLabels();
            ItemStateLabels();
            ResistanceStateLabels();
            FillCharacterState();
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
            cs.GearScoreBonus();
            MainStateLabels();
            AbilitiesLabels();
            OffenceStateLabels();
            SurvivalStateLabels();
            BonusStateLabels();
            DefenceStateLabels();
            ProffessionStateLabels();
            AdditionalStateLabels();
            OtherStateLabels();
            ItemStateLabels();
            ResistanceStateLabels();
            FillCharacterState();
        }

        private void CharacterS_btn_Click(object sender, RoutedEventArgs e)
        {
            CharacterS_border.Visibility = Visibility.Visible;
            JournalsS_border.Visibility = Visibility.Hidden;
        }

        private void JournalsS_btn_Click(object sender, RoutedEventArgs e)
        {
            JournalsS_border.Visibility = Visibility.Visible;
            CharacterS_border.Visibility = Visibility.Hidden;
            JournalsS_border.Margin = CharacterS_border.Margin;
        }

        private void Breath_tb_TextChanged(object sender, TextChangedEventArgs e)
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

        private void Breath_tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) | Breath_tb.Text.Length > 2) e.Handled = true;
        }

        private void Strength_tb_TextChanged(object sender, TextChangedEventArgs e)
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
        private void Strength_tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) | Strength_tb.Text.Length > 2) e.Handled = true;
        }
        private void Health_tb_TextChanged(object sender, TextChangedEventArgs e)
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
        private void Health_tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) | Health_tb.Text.Length > 2) e.Handled = true;
        }

        private void Underwear_cb_Checked(object sender, RoutedEventArgs e)
        {
            int uwluck = 1;
            if (Underwear_cb.IsChecked == true) { cLuck_n.Content = Convert.ToString(cs.cluck + uwluck); }
            else { cLuck_n.Content = Convert.ToString(cs.cluck - uwluck); }
            cs.cluck = Convert.ToInt32(cLuck_n.Content);

        }

        //IB journal
        private void IbCheckAll_cb_Checked(object sender, RoutedEventArgs e)
        {
            if (ibCheckAll_cb.IsChecked == true)
            {
                ibChapter1_cb.IsChecked = true;
                ibChapter2_cb.IsChecked = true;
                ibChapter3_cb.IsChecked = true;
                ibChapter4_cb.IsChecked = true;
                ibChapter5_cb.IsChecked = true;
                ibChapter6_cb.IsChecked = true;
                ibChapter7_cb.IsChecked = true;
                ibChapter8_cb.IsChecked = true;
                ibChapter9_cb.IsChecked = true;
                ibChapter10_cb.IsChecked = true;
            }
            else
            {
                ibChapter1_cb.IsChecked = false;
                ibChapter2_cb.IsChecked = false;
                ibChapter3_cb.IsChecked = false;
                ibChapter4_cb.IsChecked = false;
                ibChapter5_cb.IsChecked = false;
                ibChapter6_cb.IsChecked = false;
                ibChapter7_cb.IsChecked = false;
                ibChapter8_cb.IsChecked = false;
                ibChapter9_cb.IsChecked = false;
                ibChapter10_cb.IsChecked = false;
            }
        }
        private void IbChapter1_cb_Checked(object sender, RoutedEventArgs e)
        {
            if (ibChapter1_cb.IsChecked == true) { cs.cMaxHP += 6; cs.cMaxST += 5; }
            else { cs.cMaxHP -= 6; cs.cMaxST -= 5; }
            FillCharacterState();
        }
        private void IbChapter2_cb_Checked(object sender, RoutedEventArgs e)
        {
            if (ibChapter2_cb.IsChecked == true) { cs.cWeight += 4; cs.cacc += 1; cs.cMaxHP += 6; cs.cMaxST += 5; }
            else { cs.cWeight -= 4; cs.cacc -= 1; cs.cMaxHP -= 6; cs.cMaxST -= 5; }
            FillCharacterState();
        }
        private void IbChapter3_cb_Checked(object sender, RoutedEventArgs e)
        {
            if (ibChapter3_cb.IsChecked == true) { cs.cWeight += 2; cs.cdp += 1; cs.cMaxHP += 6; cs.cMaxST += 5; }
            else { cs.cWeight -= 2; cs.cdp -= 1; cs.cMaxHP -= 6; cs.cMaxST -= 5; }
            FillCharacterState();
        }
        private void IbChapter4_cb_Checked(object sender, RoutedEventArgs e)
        {
            if (ibChapter4_cb.IsChecked == true) { cs.cMaxHP += 6; cs.cMaxST += 5; cs.cev += 2; }
            else { cs.cMaxHP -= 6; cs.cMaxST -= 5; cs.cev -= 2; }
            FillCharacterState();
        }
        private void IbChapter5_cb_Checked(object sender, RoutedEventArgs e)
        {
            if (ibChapter5_cb.IsChecked == true) { cs.cWeight += 3; cs.cacc += 2; cs.cMaxHP += 3; cs.cMaxST += 5; }
            else { cs.cWeight -= 3; cs.cacc -= 2; cs.cMaxHP -= 3; cs.cMaxST -= 5; }
            FillCharacterState();
        }
        private void IbChapter6_cb_Checked(object sender, RoutedEventArgs e)
        {
            if (ibChapter6_cb.IsChecked == true) { cs.cap += 1; cs.cacc += 1; cs.cMaxHP += 8; cs.cMaxST += 5; }
            else { cs.cap -= 1; cs.cacc -= 1; cs.cMaxHP -= 8; cs.cMaxST -= 5; }
            FillCharacterState();
        }
        private void IbChapter7_cb_Checked(object sender, RoutedEventArgs e)
        {
            if (ibChapter7_cb.IsChecked == true) { cs.cWeight += 5; cs.cMaxHP += 6; cs.cMaxST += 10; }
            else { cs.cWeight -= 5; cs.cMaxHP -= 6; cs.cMaxST -= 10; }
            FillCharacterState();
        }
        private void IbChapter8_cb_Checked(object sender, RoutedEventArgs e)
        {
            if (ibChapter8_cb.IsChecked == true) { cs.cWeight += 2; cs.cacc += 2; cs.cMaxHP += 14; cs.cev += 1; }
            else { cs.cWeight -= 2; cs.cacc -= 2; cs.cMaxHP -= 14; cs.cev -= 1; }
            FillCharacterState();
        }
        private void IbChapter9_cb_Checked(object sender, RoutedEventArgs e)
        {
            if (ibChapter9_cb.IsChecked == true) { cs.cWeight += 3; cs.cacc += 2; cs.cMaxHP += 3; cs.cMaxST += 5; }
            else { cs.cWeight -= 3; cs.cacc -= 2; cs.cMaxHP -= 3; cs.cMaxST -= 5; }
            FillCharacterState();
        }
        private void IbChapter10_cb_Checked(object sender, RoutedEventArgs e)
        {
            if (ibChapter10_cb.IsChecked == true) { cs.cev += 2; cs.cMaxHP += 6; cs.cMaxST += 5; }
            else { cs.cev -= 2; cs.cMaxHP -= 6; cs.cMaxST -= 5; }
            FillCharacterState();
        }
        //RT journal
        private void RtChapter1_cb_Checked(object sender, RoutedEventArgs e)
        {
            if (rtChapter1_cb.IsChecked == true) { cs.cWeight += 6; cs.cMaxHP += 18; }
            else { cs.cWeight -= 6; cs.cMaxHP -= 18; }
            FillCharacterState();
        }

        private void MainStateLabels()
        {
            bool FirstPos = false;
            Thickness FirstThk_lbl = new Thickness(10, 0, 131, 176);
            Thickness FirstThk_n = new Thickness(115, 0, 34, 176);
            bool SecondPos = false;
            Thickness SecondThk_lbl = new Thickness(10, 26, 69, 150);
            Thickness SecondThk_n = new Thickness(115, 26, 34, 150);
            bool ThirdPos = false;
            Thickness ThirdThk_lbl = new Thickness(10, 52, 130, 124);
            Thickness ThirdThk_n = new Thickness(115, 52, 34, 124);
            bool FourthPos = false;
            Thickness FouthThk_lbl = new Thickness(10, 78, 101, 98);
            Thickness FouthThk_n = new Thickness(115, 78, 34, 98);
            bool FifthPos = false;
            Thickness FifthThk_lbl = new Thickness(10, 104, 102, 72);
            Thickness FifthThk_n = new Thickness(115, 104, 34, 72);
            bool SixthPos = false;
            Thickness SixthThk_lbl = new Thickness(10, 129, 77, 47);
            Thickness SixthThk_n = new Thickness(115, 129, 34, 47);
            bool SeventhPos = false;
            Thickness SeventhThk_lbl = new Thickness(11, 155, 77, 21);
            Thickness SeventhThk_n = new Thickness(115, 155, 34, 21);




            cAP_lbl.Visibility = Visibility.Collapsed;
            cAP_n.Visibility = Visibility.Collapsed;
            cAAP_lbl.Visibility = Visibility.Collapsed;
            cAAP_n.Visibility = Visibility.Collapsed;
            cDP_lbl.Visibility = Visibility.Collapsed;
            cDP_n.Visibility = Visibility.Collapsed;
            cHP_lbl.Visibility = Visibility.Collapsed;
            cHP_n.Visibility = Visibility.Collapsed;
            cMP_lbl.Visibility = Visibility.Collapsed;
            cMP_n.Visibility = Visibility.Collapsed;
            cStamina_lbl.Visibility = Visibility.Collapsed;
            cStamina_n.Visibility = Visibility.Collapsed;
            cWeight_lbl.Visibility = Visibility.Collapsed;
            cWeight_n.Visibility = Visibility.Collapsed;

            if (cs.cap != 0)
            {
                cAP_lbl.Visibility = Visibility.Visible;
                cAP_n.Visibility = Visibility.Visible;
                FirstPos = true;
            }

            if (cs.caap != 0)
            {
                cAAP_lbl.Visibility = Visibility.Visible;
                cAAP_n.Visibility = Visibility.Visible;
                if (FirstPos == false)
                {

                    cAAP_n.Margin = FirstThk_n;
                    cAAP_lbl.Margin = FirstThk_lbl;
                    FirstPos = true;
                }

                else 
                {
                    SecondPos = true;
                    cAAP_n.Margin = SecondThk_n;
                    cAAP_lbl.Margin = SecondThk_lbl;
                }
            }

            if (cs.cdp != 0)
            {
                cDP_lbl.Visibility = Visibility.Visible;
                cDP_n.Visibility = Visibility.Visible;
                if (FirstPos == false)
                {
                    cDP_n.Margin = FirstThk_n;
                    cDP_lbl.Margin = FirstThk_lbl; ;
                    FirstPos = true;
                }

                else if (SecondPos == false)
                {
                    cDP_n.Margin = SecondThk_n;
                    cDP_lbl.Margin = SecondThk_lbl;
                    SecondPos = true;
                }
                else
                {
                    ThirdPos = true;
                    cDP_n.Margin = ThirdThk_n;
                    cDP_lbl.Margin = ThirdThk_lbl;
                }

            }

            if (cs.cMaxHP != 0)
            {
                cHP_lbl.Visibility = Visibility.Visible;
                cHP_n.Visibility = Visibility.Visible;

                if (FirstPos == false)
                {
                    cHP_n.Margin = FirstThk_n;
                    cHP_lbl.Margin = FirstThk_lbl; ;
                    FirstPos = true;
                }

                else if (SecondPos == false)
                {
                    cHP_n.Margin = SecondThk_n;
                    cHP_lbl.Margin = SecondThk_lbl;
                    SecondPos = true;
                }

                else if (ThirdPos == false)
                {
                    cHP_n.Margin = ThirdThk_n;
                    cHP_lbl.Margin = ThirdThk_lbl;
                    ThirdPos = true;
                }
                else
                {
                    cHP_n.Margin = FouthThk_n;
                    cHP_lbl.Margin = FouthThk_lbl;
                    FourthPos = true;
                }

            }

            if (cs.cMaxMP != 0)
            {
                cMP_lbl.Visibility = Visibility.Visible;
                cMP_n.Visibility = Visibility.Visible;

                if (FirstPos == false)
                {
                    cMP_n.Margin = FirstThk_n;
                    cMP_lbl.Margin = FirstThk_lbl; ;
                    FirstPos = true;
                }

                else if (SecondPos == false)
                {
                    cMP_n.Margin = SecondThk_n;
                    cMP_lbl.Margin = SecondThk_lbl;
                    SecondPos = true;
                }

                else if (ThirdPos == false)
                {
                    cMP_n.Margin = ThirdThk_n;
                    cMP_lbl.Margin = ThirdThk_lbl;
                    ThirdPos = true;
                }

                else if (FourthPos == false)
                {
                    cMP_n.Margin = FouthThk_n;
                    cMP_lbl.Margin = FouthThk_lbl;
                    FourthPos = true;
                }
                else
                {
                    cMP_n.Margin = FifthThk_n;
                    cMP_lbl.Margin = FifthThk_lbl;
                    FifthPos = true;
                }

            }

            if (cs.cMaxST != 0)
            {
                cStamina_lbl.Visibility = Visibility.Visible;
                cStamina_n.Visibility = Visibility.Visible;

                if (FirstPos == false)
                {
                    cStamina_n.Margin = FirstThk_n;
                    cStamina_lbl.Margin = FirstThk_lbl; ;
                    FirstPos = true;
                }

                else if (SecondPos == false)
                {
                    cStamina_n.Margin = SecondThk_n;
                    cStamina_lbl.Margin = SecondThk_lbl;
                    SecondPos = true;
                }

                else if (ThirdPos == false)
                {
                    cStamina_n.Margin = ThirdThk_n;
                    cStamina_lbl.Margin = ThirdThk_lbl;
                    ThirdPos = true;
                }

                else if (FourthPos == false)
                {
                    cStamina_n.Margin = FouthThk_n;
                    cStamina_lbl.Margin = FouthThk_lbl;
                    FourthPos = true;
                }

                else if (FifthPos == false)
                {
                    cStamina_n.Margin = FifthThk_n;
                    cStamina_lbl.Margin = FifthThk_lbl;
                    FifthPos = true;
                }
                else
                {
                    cStamina_n.Margin = SixthThk_n;
                    cStamina_lbl.Margin = SixthThk_lbl;
                    SixthPos = true;
                }
            }

            if (cs.cWeight != 0)
            {
                cWeight_lbl.Visibility = Visibility.Visible;
                cWeight_n.Visibility = Visibility.Visible;

                if (FirstPos == false)
                {
                    cWeight_n.Margin = FirstThk_n;
                    cWeight_lbl.Margin = FirstThk_lbl; ;
                    FirstPos = true;
                }

                else if (SecondPos == false)
                {
                    cWeight_n.Margin = SecondThk_n;
                    cWeight_lbl.Margin = SecondThk_lbl;
                    SecondPos = true;
                }

                else if (ThirdPos == false)
                {
                    cWeight_n.Margin = ThirdThk_n;
                    cWeight_lbl.Margin = ThirdThk_lbl;
                    ThirdPos = true;
                }

                else if (FourthPos == false)
                {
                    cWeight_n.Margin = FouthThk_n;
                    cWeight_lbl.Margin = FouthThk_lbl;
                    FourthPos = true;
                }

                else if (FifthPos == false)
                {
                    cWeight_n.Margin = FifthThk_n;
                    cWeight_lbl.Margin = FifthThk_lbl;
                    FifthPos = true;
                }

                else if (SixthPos == false)
                {
                    cWeight_n.Margin = SixthThk_n;
                    cWeight_lbl.Margin = SixthThk_lbl;
                    SixthPos = true;
                }
                else
                {
                    cWeight_n.Margin = SeventhThk_n;
                    cWeight_lbl.Margin = SeventhThk_lbl;
                    SeventhPos = true;
                }
            }



            if (SeventhPos == true)
            {

                MainStatsExp.Height = 203;
                MainStatsExp.Margin = new Thickness(0, 0, 0, 444);
            }
            else if (SixthPos == true)
            {
                MainStatsExp.Margin = new Thickness(0, 0, 0, 471);
                MainStatsExp.Height = 176;
            }

            else if (FifthPos == true)
            {
                MainStatsExp.Margin = new Thickness(0, 0, 0, 497);
                MainStatsExp.Height = 150;
            }

            else if (FourthPos == true)
            {
                MainStatsExp.Margin = new Thickness(0, 0, 0, 521);
                MainStatsExp.Height = 126;
            }
            else if (ThirdPos == true)
            {
                MainStatsExp.Margin = new Thickness(0, 0, 0, 547);
                MainStatsExp.Height = 100;
            }
            else if (SecondPos == true)
            {
                MainStatsExp.Margin = new Thickness(0, 0, 0, 572);
                MainStatsExp.Height = 75;
            }
            else if (FirstPos == true)
            {
                MainStatsExp.Margin = new Thickness(0, 0, 0, 600);
                MainStatsExp.Height = 47;
            }

            else
            {
                MainStatsExp.Margin = new Thickness(0, 0, 0, 623);
                MainStatsExp.Height = 24;
            }


        }

        private void AbilitiesLabels()
        {
            cAtkSpeed_lbl.Visibility = Visibility.Collapsed;
            cAtkSpeed_n.Visibility = Visibility.Collapsed;
            cCastSpeed_lbl.Visibility = Visibility.Collapsed;
            cCastSpeed_n.Visibility = Visibility.Collapsed;
            cMvS_lbl.Visibility = Visibility.Collapsed;
            cCR_lbl.Visibility = Visibility.Collapsed;
            cLuck_lbl.Visibility = Visibility.Collapsed;
            cAtkSpeedRate_lbl.Visibility = Visibility.Collapsed;
            cCastSpeedRate_lbl.Visibility = Visibility.Collapsed;
            cMvS_n.Visibility = Visibility.Collapsed;
            cCR_n.Visibility = Visibility.Collapsed;
            cLuck_n.Visibility = Visibility.Collapsed;
            cAtkSpeedRate_n.Visibility = Visibility.Collapsed;
            cCastSpeedRate_n.Visibility = Visibility.Collapsed;



            Label[] Abilities_lbl = new Label[7] { cAtkSpeed_lbl, cCastSpeed_lbl, cMvS_lbl, cCR_lbl, cLuck_lbl, cAtkSpeedRate_lbl, cCastSpeedRate_lbl };
            Label[] Abilities_n = new Label[7] { cAtkSpeed_n, cCastSpeed_n, cMvS_n, cCR_n, cLuck_n, cAtkSpeedRate_n, cCastSpeedRate_n };
            Thickness[] lbl_thk = new Thickness[7] { new Thickness(10, 0, 0, 0), new Thickness(10, 26, 0, 0), new Thickness(10, 52, 0, 0), new Thickness(10, 78, 0, 0), new Thickness(10, 104, 0, 0), new Thickness(10, 130, 0, 0), new Thickness(10, 156, 0, 0) };
            Thickness[] n_thk = new Thickness[7] { new Thickness(118, 0, 0, 0), new Thickness(118, 26, 0, 0), new Thickness(118, 52, 0, 0), new Thickness(118, 78, 0, 0), new Thickness(118, 104, 0, 0), new Thickness(118, 130, 0, 0), new Thickness(118, 156, 0, 0) };
            int[] Abilities = new int[7] { cs.cAtkSpeed, cs.cCastSpeed, cs.cmvs, cs.ccr, cs.cluck, cs.cAtkSpeedRate, cs.cCastSpeedRate };
            int PositionCheck = 0;




            for (int i = 0; i < Abilities.Length; i++)
            {
                if (Abilities[i] != 0)
                {
                    Abilities_lbl[i].Margin = lbl_thk[PositionCheck];
                    Abilities_n[i].Margin = n_thk[PositionCheck];
                    Abilities_lbl[i].Visibility = Visibility.Visible;
                    Abilities_n[i].Visibility = Visibility.Visible;
                    PositionCheck++;
                }
            }

            
            if (PositionCheck == 7)
            {
                AbilitiesStatsExp.Margin = new Thickness(0, MainStatsExp.Height + 5, 0, 232 +(203- MainStatsExp.Height));
                AbilitiesStatsExp.Height = 207;
            }
            else if (PositionCheck == 6)
            {
                AbilitiesStatsExp.Margin = new Thickness(0, MainStatsExp.Height + 5, 0, 261 + (203 - MainStatsExp.Height));
                AbilitiesStatsExp.Height = 178;
            }
            else if (PositionCheck == 5)
            {
                AbilitiesStatsExp.Margin = new Thickness(0, MainStatsExp.Height + 5, 0, 288 + (203 - MainStatsExp.Height));
                AbilitiesStatsExp.Height = 151;
            }
            else if (PositionCheck == 4)
            {
                AbilitiesStatsExp.Margin = new Thickness(0, MainStatsExp.Height + 5, 0, 309 + (203 - MainStatsExp.Height));
                AbilitiesStatsExp.Height = 130;
            }
            else if (PositionCheck == 3)
            {
                AbilitiesStatsExp.Margin = new Thickness(0, MainStatsExp.Height + 5, 0, 340 + (203 - MainStatsExp.Height));
                AbilitiesStatsExp.Height = 99;
            }
            else if (PositionCheck == 2)
            {
                AbilitiesStatsExp.Margin = new Thickness(0, MainStatsExp.Height + 5, 0, 365 + (203 - MainStatsExp.Height));
                AbilitiesStatsExp.Height = 74;
            }
            else if (PositionCheck == 1)
            {
                AbilitiesStatsExp.Margin = new Thickness(0, MainStatsExp.Height + 5, 0, 391 + (203 - MainStatsExp.Height));
                AbilitiesStatsExp.Height = 48;
            }

            else
            {
                AbilitiesStatsExp.Margin = new Thickness(0, MainStatsExp.Height + 5, 0, 416 + (203 - MainStatsExp.Height));
                AbilitiesStatsExp.Height = 23;
            }

            


        }
        
        private void OffenceStateLabels()
        {
            cHAP_lbl.Visibility = Visibility.Collapsed;
            cMagicAP_lbl.Visibility = Visibility.Collapsed;
            cMelleAP_lbl.Visibility = Visibility.Collapsed;
            cRangeAP_lbl.Visibility = Visibility.Collapsed;
            cAcc_lbl.Visibility = Visibility.Collapsed;
            cIgnoreResistance_lbl.Visibility = Visibility.Collapsed;
            cIgnoreGrapleResistance_lbl.Visibility = Visibility.Collapsed;
            cIgnoreKDResistance_lbl.Visibility = Visibility.Collapsed;
            cIgnoreKBResistance_lbl.Visibility = Visibility.Collapsed;
            cIgnoreStunResistance_lbl.Visibility = Visibility.Collapsed;
            cAtkSpeedDmg_lbl.Visibility = Visibility.Collapsed;

            cHAP_n.Visibility = Visibility.Collapsed;
            cMagicAP_n.Visibility = Visibility.Collapsed;
            cMelleAP_n.Visibility = Visibility.Collapsed;
            cRangeAP_n.Visibility = Visibility.Collapsed;
            cAcc_n.Visibility = Visibility.Collapsed;
            cIgnoreResistance_n.Visibility = Visibility.Collapsed;
            cIgnoreGrapleResistance_n.Visibility = Visibility.Collapsed;
            cIgnoreKDResistance_n.Visibility = Visibility.Collapsed;
            cIgnoreKBResistance_n.Visibility = Visibility.Collapsed;
            cIgnoreStunResistance_n.Visibility = Visibility.Collapsed;
            cAtkSpeedDmg_n.Visibility = Visibility.Collapsed;




            Label[] Offence_lbl = new Label[11] { cHAP_lbl, cMagicAP_lbl, cMelleAP_lbl, cRangeAP_lbl, cAcc_lbl, cIgnoreResistance_lbl, cIgnoreGrapleResistance_lbl, cIgnoreKDResistance_lbl, cIgnoreKBResistance_lbl, cIgnoreStunResistance_lbl, cAtkSpeedDmg_lbl };
            Label[]  Offence_n = new Label[11] { cHAP_n, cMagicAP_n, cMelleAP_n, cRangeAP_n, cAcc_n, cIgnoreResistance_n, cIgnoreGrapleResistance_n, cIgnoreKDResistance_n, cIgnoreKBResistance_n, cIgnoreStunResistance_n, cAtkSpeedDmg_n };
            Thickness[] lbl_thk = new Thickness[11] { new Thickness(10, 0, 0, 0), new Thickness(10, 26, 0, 0), new Thickness(10, 52, 0, 0), new Thickness(10, 78, 0, 0), new Thickness(10, 104, 0, 0), new Thickness(10, 130, 0, 0), new Thickness(10, 156, 0, 0), new Thickness(10, 181, 0, 0), new Thickness(10,205,0,0), new Thickness(10,231, 0 , 0), new Thickness(10,257,0,0)};
            Thickness[] n_thk = new Thickness[11] { new Thickness(152, 0, 0, 0), new Thickness(152, 26, 0, 0), new Thickness(152, 52, 0, 0), new Thickness(152, 78, 0, 0), new Thickness(152, 104, 0, 0), new Thickness(152, 130, 0, 0), new Thickness(152, 156, 0, 0), new Thickness(152, 181, 0, 0), new Thickness(152, 205, 0, 0), new Thickness(152, 231, 0, 0), new Thickness(152, 257, 0, 0) };
            int[] Offence = new int[11] {cs.chap, cs.cMagicAP, cs.cMelleAP, cs.cRangeAP, cs.cacc, cs.cResistIgnore, cs.cGrapResistIgnore, cs.cKDResistIgnore, cs.cKBResistIgnore, cs.cStunResistIgnore, cs.cSpeedAtkDmg };
            int PositionCheck = 0;

            for (int i = 0; i < Offence.Length; i++)
            {
                if (Offence[i] != 0)
                {
                    Offence_lbl[i].Margin = lbl_thk[PositionCheck];
                    Offence_n[i].Margin = n_thk[PositionCheck];
                    Offence_lbl[i].Visibility = Visibility.Visible;
                    Offence_n[i].Visibility = Visibility.Visible;
                    PositionCheck++;
                }
            }

            if (PositionCheck == 11)
            {
                OffenceStatsExp.Height = 307;
            }

            else if (PositionCheck == 10)
            {
                OffenceStatsExp.Height = 282;
            }
            else if (PositionCheck == 9)
            {
                OffenceStatsExp.Height = 254;
            }
            else if (PositionCheck == 8)
            {
                OffenceStatsExp.Height = 230;
            }
            else if (PositionCheck == 7)
            {
                OffenceStatsExp.Height = 203;
            }
            else if (PositionCheck == 6)
            {
                OffenceStatsExp.Height = 180;
            }
            else if (PositionCheck == 5)
            {
                OffenceStatsExp.Height = 150;
            }
            else if (PositionCheck == 4)
            {
                OffenceStatsExp.Height = 128;
            }
            else if (PositionCheck == 3)
            {
                OffenceStatsExp.Height = 101;
            }
            else if (PositionCheck == 2)
            {
                OffenceStatsExp.Height = 76;
            }
            else if (PositionCheck == 1)
            {
                OffenceStatsExp.Height = 52;
            }
            else
            {
                OffenceStatsExp.Height = 24;
            }
           
        }

        private void SurvivalStateLabels()
        {
            cHPR_lbl.Visibility = Visibility.Collapsed;
            cMPR_lbl.Visibility = Visibility.Collapsed;
            cHPRecoveryChance_lbl.Visibility = Visibility.Collapsed;
            cHPR_n.Visibility = Visibility.Collapsed;
            cMPR_n.Visibility = Visibility.Collapsed;
            cHPRecoveryChance_n.Visibility = Visibility.Collapsed;


            Label[] Survival_lbl = new Label[3] { cHPR_lbl, cMPR_lbl, cHPRecoveryChance_lbl };
            Label[] Survival_n = new Label[3] { cHPR_n, cMPR_n, cHPRecoveryChance_n };
            Thickness[] lbl_thk = new Thickness[3] { new Thickness(10, 0, 0, 0), new Thickness(10, 26, 0, 0), new Thickness(10, 52, 0, 0) };
            Thickness[] n_thk = new Thickness[3] { new Thickness(218, 0, 0, 0), new Thickness(218, 26, 0, 0), new Thickness(218, 52, 0, 0) };
            int[] Survival = new int[3] {cs.chpr, cs.cmpr, cs.cHPrecoveryChance };
            int PositionCheck = 0;

            for (int i = 0; i < Survival.Length; i++)
            {
                if (Survival[i] != 0)
                {
                    Survival_lbl[i].Margin = lbl_thk[PositionCheck];
                    Survival_n[i].Margin = n_thk[PositionCheck];
                    Survival_lbl[i].Visibility = Visibility.Visible;
                    Survival_n[i].Visibility = Visibility.Visible;
                    PositionCheck++;
                }
            }

                SurvivalStatesExp.Margin = new Thickness(170, OffenceStatsExp.Height + 5, 0, 232 + (307  - OffenceStatsExp.Height));

        }

        private void BonusStateLabels()
        {
            cSpiritRage_lbl.Visibility = Visibility.Collapsed;
            cBonusAP_lbl.Visibility = Visibility.Collapsed;
            cBonusAAP_lbl.Visibility = Visibility.Collapsed;
            cBonusDR_lbl.Visibility = Visibility.Collapsed;
            cCombatEXP_lbl.Visibility = Visibility.Collapsed;
            cSkillEXP_lbl.Visibility = Visibility.Collapsed;

            cSpiritRage_n.Visibility = Visibility.Collapsed;
            cBonusAP_n.Visibility = Visibility.Collapsed;
            cBonusAAP_n.Visibility = Visibility.Collapsed;
            cBonusDR_n.Visibility = Visibility.Collapsed;
            cCombatEXP_n.Visibility = Visibility.Collapsed;
            cSkillEXP_n.Visibility = Visibility.Collapsed;


            Label[] Bonus_lbl = new Label[6] { cSpiritRage_lbl, cBonusAP_lbl, cBonusAAP_lbl, cBonusDR_lbl, cCombatEXP_lbl, cSkillEXP_lbl };
            Label[] Bonus_n = new Label[6] { cSpiritRage_n, cBonusAP_n, cBonusAAP_n, cBonusDR_n, cCombatEXP_n, cSkillEXP_n };
            Thickness[] lbl_thk = new Thickness[6] { new Thickness(10, 0, 0, 0), new Thickness(10, 26, 0, 0), new Thickness(10, 52, 0, 0), new Thickness(10, 78, 0, 0), new Thickness(10, 104, 0, 0), new Thickness(10, 130, 0, 0) };
            Thickness[] n_thk = new Thickness[6] { new Thickness(116, 0, 0, 0), new Thickness(116, 26, 0, 0), new Thickness(116, 52, 0, 0), new Thickness(116, 78, 0, 0), new Thickness(116, 104, 0, 0), new Thickness(116, 130, 0, 0) };
            int[] Bonus = new int[6] { cs.cSpiritRage, cs.bcap, cs.bcaap, Convert.ToInt32(cs.bcdr), cs.cCombatExp, cs.cSkillExp};
            int PositionCheck = 0;

            for (int i = 0; i < Bonus.Length; i++)
            {
                if (Bonus[i] != 0)
                {
                    Bonus_lbl[i].Margin = lbl_thk[PositionCheck];
                    Bonus_n[i].Margin = n_thk[PositionCheck];
                    Bonus_lbl[i].Visibility = Visibility.Visible;
                    Bonus_n[i].Visibility = Visibility.Visible;
                    PositionCheck++;
                }
            }

            BonusStatesExp.Margin = new Thickness(0,  MainStatsExp.Height + AbilitiesStatsExp.Height+ 5, 0, 232 + (207 - AbilitiesStatsExp.Height));

        }

        private void DefenceStateLabels()
        {
            cDR_lbl.Visibility = Visibility.Collapsed;
            cHDR_lbl.Visibility = Visibility.Collapsed;
            cEvas_lbl.Visibility = Visibility.Collapsed;
            cHE_lbl.Visibility = Visibility.Collapsed;
            cMagicDR_lbl.Visibility = Visibility.Collapsed;
            cMelleDR_lbl.Visibility = Visibility.Collapsed;
            cRangeDR_lbl.Visibility = Visibility.Collapsed;
            cDFM_lbl.Visibility = Visibility.Collapsed;
            cSpecialAttackEvRate_lbl.Visibility = Visibility.Collapsed;
            cSiegeWeaponEvRate_lbl.Visibility = Visibility.Collapsed;

            cDR_n.Visibility = Visibility.Collapsed;
            cHDR_n.Visibility = Visibility.Collapsed;
            cEvas_n.Visibility = Visibility.Collapsed;
            cHE_n.Visibility = Visibility.Collapsed;
            cMagicDR_n.Visibility = Visibility.Collapsed;
            cMelleDR_n.Visibility = Visibility.Collapsed;
            cRangeDR_n.Visibility = Visibility.Collapsed;
            cDFM_n.Visibility = Visibility.Collapsed;
            cSpecialAttackEvRate_n.Visibility = Visibility.Collapsed;
            cSiegeWeaponEvRate_n.Visibility = Visibility.Collapsed;


            Label[] Defence_lbl = new Label[10] { cDR_lbl, cHDR_lbl, cEvas_lbl, cHE_lbl, cMagicDR_lbl, cMelleDR_lbl, cRangeDR_lbl, cDFM_lbl, cSiegeWeaponEvRate_lbl, cSpecialAttackEvRate_lbl };
            Label[] Defence_n = new Label[10] { cDR_n, cHDR_n, cEvas_n, cHE_n, cMagicDR_n, cMelleDR_n, cRangeDR_n, cDFM_n, cSiegeWeaponEvRate_n, cSpecialAttackEvRate_n };
            Thickness[] lbl_thk = new Thickness[10] { new Thickness(10, 0, 0, 0), new Thickness(10, 26, 0, 0), new Thickness(10, 52, 0, 0), new Thickness(10, 78, 0, 0), new Thickness(10, 104, 0, 0), new Thickness(10, 130, 0, 0) , new Thickness (6, 155, 0, 0), new Thickness(6, 181, 0, 0), new Thickness(6, 207, 0, 0), new Thickness(6, 233, 0, 0) };
            Thickness[] n_thk = new Thickness[10] { new Thickness(165, 0, 0, 0), new Thickness(165, 26, 0, 0), new Thickness(165, 52, 0, 0), new Thickness(165, 78, 0, 0), new Thickness(165, 104, 0, 0), new Thickness(165, 130, 0, 0), new Thickness(165, 155, 0, 0), new Thickness(165, 181, 0, 0), new Thickness(165, 207, 0, 0), new Thickness(165, 233, 0, 0) };
            int[] Defence = new int[10] { cs.cDR, cs.chdr, cs.cev, cs.chev, cs.cMagicDR, cs.cMeleeDR, cs.cRangeDR, cs.cdfm, cs.cSiegeWeaponEvRate, cs.cSpecialAttackEv };
            int PositionCheck = 0;

            for (int i = 0; i < Defence.Length; i++)
            {
                if (Defence[i] != 0)
                {
                    Defence_lbl[i].Margin = lbl_thk[PositionCheck];
                    Defence_n[i].Margin = n_thk[PositionCheck];
                    Defence_lbl[i].Visibility = Visibility.Visible;
                    Defence_n[i].Visibility = Visibility.Visible;
                    PositionCheck++;
                }
            }


            if (PositionCheck == 10)
            {
                DefenceStateExp.Height = 282;
            }
            else if (PositionCheck == 9)
            {
                DefenceStateExp.Height = 254;
            }
            else if (PositionCheck == 8)
            {
                DefenceStateExp.Height = 230;
            }
            else if (PositionCheck == 7)
            {
                DefenceStateExp.Height = 203;
            }
            else if (PositionCheck == 6)
            {
                DefenceStateExp.Height = 180;
            }
            else if (PositionCheck == 5)
            {
                DefenceStateExp.Height = 150;
            }
            else if (PositionCheck == 4)
            {
                DefenceStateExp.Height = 128;
            }
            else if (PositionCheck == 3)
            {
                DefenceStateExp.Height = 101;
            }
            else if (PositionCheck == 2)
            {
                DefenceStateExp.Height = 76;
            }
            else if (PositionCheck == 1)
            {
                DefenceStateExp.Height = 52;
            }
            else
            {
                DefenceStateExp.Height = 24;
            }

        }

        private void ProffessionStateLabels()
        {
            cProcessingRate_lbl.Visibility = Visibility.Collapsed;
            cGathDropRate_lbl.Visibility = Visibility.Collapsed;
            cGathering_lbl.Visibility = Visibility.Collapsed;
            cFishing_lbl.Visibility = Visibility.Collapsed;
            cAlchCookTime_lbl.Visibility = Visibility.Collapsed;

            cProcessingRate_n.Visibility = Visibility.Collapsed;
            cGathDropRate_n.Visibility = Visibility.Collapsed;
            cGathering_n.Visibility = Visibility.Collapsed;
            cFishing_n.Visibility = Visibility.Collapsed;
            cAlchCookTime_n.Visibility = Visibility.Collapsed;


            Label[] Proffession_lbl = new Label[5] { cProcessingRate_lbl, cGathDropRate_lbl, cGathering_lbl, cFishing_lbl, cAlchCookTime_lbl};
            Label[] Proffession_n = new Label[5] { cProcessingRate_n, cGathDropRate_n, cGathering_n, cFishing_n, cAlchCookTime_n };
            Thickness[] lbl_thk = new Thickness[5] { new Thickness(10, 0, 0, 0), new Thickness(10, 26, 0, 0), new Thickness(10, 52, 0, 0), new Thickness(10, 78, 0, 0), new Thickness(10, 104, 0, 0)};
            Thickness[] n_thk = new Thickness[5] { new Thickness(159, 0, 0, 0), new Thickness(159, 26, 0, 0), new Thickness(159, 52, 0, 0), new Thickness(159, 78, 0, 0), new Thickness(159, 104, 0, 0)};
            int[] Proffession = new int[5] { cs.cProccesingRate, cs.cGathDropRate, cs.cGathering, cs.cFishing, Convert.ToInt32(cs.cAlchCookTime) };
            int PositionCheck = 0;

            for (int i = 0; i < Proffession.Length; i++)
            {
                if (Proffession[i] != 0)
                {
                    Proffession_lbl[i].Margin = lbl_thk[PositionCheck];
                    Proffession_n[i].Margin = n_thk[PositionCheck];
                    Proffession_lbl[i].Visibility = Visibility.Visible;
                    Proffession_n[i].Visibility = Visibility.Visible;
                    PositionCheck++;
                }
            }

            ProffessionStatesExp.Margin = new Thickness(409, DefenceStateExp.Height + 5, 0, 150 + (282 - DefenceStateExp.Height));

        }

        private void AdditionalStateLabels()
        {
            cCHDamage_lbl.Visibility = Visibility.Collapsed;
            cEDA_lbl.Visibility = Visibility.Collapsed;
            cEDH_lbl.Visibility = Visibility.Collapsed;
            cEAPa_lbl.Visibility = Visibility.Collapsed;
            cExtraDamKama_lbl.Visibility = Visibility.Collapsed;
            cADtDemiH_lbl.Visibility = Visibility.Collapsed;
            cEDtAExcHumanAndDemi_lbl.Visibility = Visibility.Collapsed;
            cEDtoAir_lbl.Visibility = Visibility.Collapsed;
            cEDtoCounter_lbl.Visibility = Visibility.Collapsed;
            cEDtoDown_lbl.Visibility = Visibility.Collapsed;
            cEDtoBack_lbl.Visibility = Visibility.Collapsed;
            cSpecialAttackED_lbl.Visibility = Visibility.Collapsed;

            cCHDamage_n.Visibility = Visibility.Collapsed;
            cEDA_n.Visibility = Visibility.Collapsed;
            cEDH_n.Visibility = Visibility.Collapsed;
            cEAPa_n.Visibility = Visibility.Collapsed;
            cExtraDamKama_n.Visibility = Visibility.Collapsed;
            cADtDemiH_n.Visibility = Visibility.Collapsed;
            cEDtAExcHumanAndDemi_n.Visibility = Visibility.Collapsed;
            cEDtoAir_n.Visibility = Visibility.Collapsed;
            cEDtoCounter_n.Visibility = Visibility.Collapsed;
            cEDtoDown_n.Visibility = Visibility.Collapsed;
            cEDtoBack_n.Visibility = Visibility.Collapsed;
            cSpecialAttackED_n.Visibility = Visibility.Collapsed;




            Label[] Additional_lbl = new Label[12] { cCHDamage_lbl, cEDA_lbl, cEDH_lbl, cEAPa_lbl, cExtraDamKama_lbl, cADtDemiH_lbl, cEDtAExcHumanAndDemi_lbl, cEDtoAir_lbl, cEDtoCounter_lbl, cEDtoDown_lbl, cEDtoBack_lbl, cSpecialAttackED_lbl };
            Label[] Additional_n = new Label[12] { cCHDamage_n, cEDA_n, cEDH_n, cEAPa_n, cExtraDamKama_n, cADtDemiH_n, cEDtAExcHumanAndDemi_n, cEDtoAir_n, cEDtoCounter_n, cEDtoDown_n, cEDtoBack_n, cSpecialAttackED_n };
            Thickness[] lbl_thk = new Thickness[12] { new Thickness(5, 0, 0, 0), new Thickness(5, 26, 0, 0), new Thickness(5, 52, 0, 0), new Thickness(5, 78, 0, 0), new Thickness(5, 104, 0, 0), new Thickness(5, 130, 0, 0), new Thickness(5, 156, 0, 0), new Thickness(5, 181, 0, 0), new Thickness(5, 205, 0, 0), new Thickness(5, 231, 0, 0), new Thickness(5, 257, 0, 0), new Thickness(5, 287, 0, 0) };
            Thickness[] n_thk = new Thickness[12] { new Thickness(287, 0, 0, 0), new Thickness(287, 26, 0, 0), new Thickness(287, 52, 0, 0), new Thickness(287, 78, 0, 0), new Thickness(287, 104, 0, 0), new Thickness(287, 130, 0, 0), new Thickness(287, 156, 0, 0), new Thickness(287, 181, 0, 0), new Thickness(287, 205, 0, 0), new Thickness(287, 231, 0, 0), new Thickness(287, 257, 0, 0), new Thickness(287, 287, 0, 0) };
            int[] Additional = new int[12] { cs.cCritHitDmg, cs.ceda, cs.cedh, cs.ceapa, cs.cedKama, cs.cADtDemiH, cs.cADtoAllWithExcept, cs.cEDtoAir, cs.cEDtoCounter, cs.cEDtoDown, cs.cEDtoBack, cs.cSpecialAttackDam };
            int PositionCheck = 0;

            for (int i = 0; i < Additional.Length; i++)
            {
                if (Additional[i] != 0)
                {
                    Additional_lbl[i].Margin = lbl_thk[PositionCheck];
                    Additional_n[i].Margin = n_thk[PositionCheck];
                    Additional_lbl[i].Visibility = Visibility.Visible;
                    Additional_n[i].Visibility = Visibility.Visible;
                    PositionCheck++;
                }
            }

            if(PositionCheck == 12)
            {
                AdditionalStateExp.Height = 343;

            }

            else if (PositionCheck == 11)
            {
                AdditionalStateExp.Height = 307;
            }

            else if (PositionCheck == 10)
            {
                AdditionalStateExp.Height = 282;
            }
            else if (PositionCheck == 9)
            {
                AdditionalStateExp.Height = 254;
            }
            else if (PositionCheck == 8)
            {
                AdditionalStateExp.Height = 230;
            }
            else if (PositionCheck == 7)
            {
                AdditionalStateExp.Height = 203;
            }
            else if (PositionCheck == 6)
            {
                AdditionalStateExp.Height = 180;
            }
            else if (PositionCheck == 5)
            {
                AdditionalStateExp.Height = 150;
            }
            else if (PositionCheck == 4)
            {
                AdditionalStateExp.Height = 128;
            }
            else if (PositionCheck == 3)
            {
                AdditionalStateExp.Height = 101;
            }
            else if (PositionCheck == 2)
            {
                AdditionalStateExp.Height = 76;
            }
            else if (PositionCheck == 1)
            {
                AdditionalStateExp.Height = 52;
            }
            else
            {
                AdditionalStateExp.Height = 24;
            }

        }

        private void OtherStateLabels()
        {
            cFallDamage_lbl.Visibility = Visibility.Collapsed;
            cJump_lbl.Visibility = Visibility.Collapsed;
            cUnderwaterBreath_lbl.Visibility = Visibility.Collapsed;
            cMaxEnergy_lbl.Visibility = Visibility.Collapsed;
            cVisionRange_lbl.Visibility = Visibility.Collapsed;
            cBidding_lbl.Visibility = Visibility.Collapsed;
            cMistyHev_lbl.Visibility = Visibility.Collapsed;
            cMistyHdp_lbl.Visibility = Visibility.Collapsed;
            cDelusLmvs_lbl.Visibility = Visibility.Collapsed;
            cSunMoon_lbl.Visibility = Visibility.Collapsed;

            cFallDamage_n.Visibility = Visibility.Collapsed;
            cJump_n.Visibility = Visibility.Collapsed;
            cUnderwaterBreath_n.Visibility = Visibility.Collapsed;
            cMaxEnergy_n.Visibility = Visibility.Collapsed;
            cVisionRange_n.Visibility = Visibility.Collapsed;
            cBidding_n.Visibility = Visibility.Collapsed;
            cMistyHev_n.Visibility = Visibility.Collapsed;
            cMistyHdp_n.Visibility = Visibility.Collapsed;
            cDelusLmvs_n.Visibility = Visibility.Collapsed;
            cSunMoon_n.Visibility = Visibility.Collapsed;



            Label[] Other_lbl = new Label[10] { cFallDamage_lbl, cJump_lbl, cUnderwaterBreath_lbl, cMaxEnergy_lbl, cVisionRange_lbl, cBidding_lbl, cMistyHev_lbl, cMistyHdp_lbl, cDelusLmvs_lbl, cSunMoon_lbl};
            Label[] Other_n = new Label[10] { cFallDamage_n, cJump_n, cUnderwaterBreath_n, cMaxEnergy_n, cVisionRange_n, cBidding_n, cMistyHev_n, cMistyHdp_n, cDelusLmvs_n, cSunMoon_n };
            Thickness[] lbl_thk = new Thickness[10] { new Thickness(10, 0, 0, 0), new Thickness(10, 26, 0, 0), new Thickness(10, 52, 0, 0), new Thickness(10, 78, 0, 0), new Thickness(10, 104, 0, 0), new Thickness(10, 130, 0, 0), new Thickness(10, 156, 0, 0), new Thickness(10, 181, 0, 0), new Thickness(10, 205, 0, 0), new Thickness(10, 231, 0, 0)};
            Thickness[] n_thk = new Thickness[10] { new Thickness(252, 0, 0, 0), new Thickness(252, 26, 0, 0), new Thickness(252, 52, 0, 0), new Thickness(252, 78, 0, 0), new Thickness(252, 104, 0, 0), new Thickness(252, 130, 0, 0), new Thickness(252, 156, 0, 0), new Thickness(252, 181, 0, 0), new Thickness(252, 205, 0, 0), new Thickness(252, 231, 0, 0)};
            int[] Other = new int[10] { cs.cFallDamage, cs.cJump, cs.cUnderwaterBreath, cs.cMaxEnergy, cs.cVisionRange, cs.cBidding, cs.shaiEv, cs.shaiDP, cs.shaiMvs, cs.shaiSpeed};
            int PositionCheck = 0;

            for (int i = 0; i < Other.Length; i++)
            {
                if (Other[i] != 0)
                {
                    Other_lbl[i].Margin = lbl_thk[PositionCheck];
                    Other_n[i].Margin = n_thk[PositionCheck];
                    Other_lbl[i].Visibility = Visibility.Visible;
                    Other_n[i].Visibility = Visibility.Visible;
                    PositionCheck++;
                }
            }
        }

        private void ItemStateLabels()
        {
            iAP_n.Visibility = Visibility.Collapsed;
            iAAP_n.Visibility = Visibility.Collapsed;
            iDP_n.Visibility = Visibility.Collapsed;
            iEvas_n.Visibility = Visibility.Collapsed;
            iAcc_n.Visibility = Visibility.Collapsed;
            iRes_n .Visibility = Visibility.Collapsed;
            iDR_n.Visibility = Visibility.Collapsed; 
            iHP_n.Visibility = Visibility.Collapsed;
            iWeight_n.Visibility = Visibility.Collapsed;
            iMP_n.Visibility = Visibility.Collapsed; 
            iST_n.Visibility = Visibility.Collapsed; 
            iSSFR_n .Visibility = Visibility.Collapsed;
            iKBR_n .Visibility = Visibility.Collapsed; 
            iGrapR_n .Visibility = Visibility.Collapsed;
            iKFR_n .Visibility = Visibility.Collapsed; 
            iHEV_n.Visibility = Visibility.Collapsed; 
            iHDR_n.Visibility = Visibility.Collapsed; 
            iAtkSpeed_n.Visibility = Visibility.Collapsed; 
            iCastSpeed_n.Visibility = Visibility.Collapsed; 
            iMVS_n.Visibility = Visibility.Collapsed; 
            iCrit_n.Visibility = Visibility.Collapsed;
            iExtraDamKama_n.Visibility = Visibility.Collapsed; 
            iEDtA_n.Visibility = Visibility.Collapsed; 
            iEAPa_n.Visibility = Visibility.Collapsed; 
            iMPR_n.Visibility = Visibility.Collapsed; 
            iHPR_n.Visibility = Visibility.Collapsed; 
            iLuck_n.Visibility = Visibility.Collapsed; 
            iEDH_n.Visibility = Visibility.Collapsed;
            iADtDemiH_n.Visibility = Visibility.Collapsed; 
            iEDtAExcHumanAndDemi_n.Visibility = Visibility.Collapsed; 
            iSpiritRage_n .Visibility = Visibility.Collapsed;
            iBidding_n .Visibility = Visibility.Collapsed; 
            iEDtoBack_n .Visibility = Visibility.Collapsed; 
            iHPRecoveryChance_n.Visibility = Visibility.Collapsed;
            iIgnoreResistance_n .Visibility = Visibility.Collapsed;
            iSpecialAttackED_n .Visibility = Visibility.Collapsed;
            iSpecialAttackEvRate_n .Visibility = Visibility.Collapsed;
            iHAP_n.Visibility = Visibility.Collapsed;
            iCastSpeedRate_n .Visibility = Visibility.Collapsed;
            iAtkSpeedRate_n .Visibility = Visibility.Collapsed;
            iAlchCookTime_n.Visibility = Visibility.Collapsed;
            iProcessingRate_n .Visibility = Visibility.Collapsed;
            iGathering_n.Visibility = Visibility.Collapsed;
            iFishing_n.Visibility = Visibility.Collapsed;
            iGathDropRate_n .Visibility = Visibility.Collapsed;
            iCombatEXP_n .Visibility = Visibility.Collapsed;
            iSkillEXP_n .Visibility = Visibility.Collapsed;
            iCHDamage_n .Visibility = Visibility.Collapsed;
            iAtkSpeedDmg_n .Visibility = Visibility.Collapsed;
            iEDtoAir_n .Visibility = Visibility.Collapsed;
            iEDtoCounter_n .Visibility = Visibility.Collapsed;
            iEDtoDown_n .Visibility = Visibility.Collapsed;
            iIgnoreGrapleResistance_n .Visibility = Visibility.Collapsed;
            iIgnoreKBResistance_n .Visibility = Visibility.Collapsed;
            iIgnoreKDResistance_n .Visibility = Visibility.Collapsed;
            iIgnoreStunResistance_n .Visibility = Visibility.Collapsed;
            iVisionRange_n.Visibility = Visibility.Collapsed;
            iMagicDR_n.Visibility = Visibility.Collapsed;
            iMelleDR_n.Visibility = Visibility.Collapsed;
            iRangeDR_n.Visibility = Visibility.Collapsed;
            iSiegeWeaponEvRate_n .Visibility = Visibility.Collapsed;
            iMagicAP_n.Visibility = Visibility.Collapsed;
            iMelleAP_n.Visibility = Visibility.Collapsed;
            iRangeAP_n.Visibility = Visibility.Collapsed;
            iJump_n.Visibility = Visibility.Collapsed;
            iFallDamage_n.Visibility = Visibility.Collapsed;
            iUnderwaterBreath_n.Visibility = Visibility.Collapsed;
            iMaxEnergy_n.Visibility = Visibility.Collapsed;

            iAP_lbl.Visibility = Visibility.Collapsed;
            iAAP_lbl.Visibility = Visibility.Collapsed;
            iDP_lbl.Visibility = Visibility.Collapsed;
            iEvas_lbl.Visibility = Visibility.Collapsed;
            iAcc_lbl.Visibility = Visibility.Collapsed;
            iRes_lbl.Visibility = Visibility.Collapsed;
            iDR_lbl.Visibility = Visibility.Collapsed;
            iHP_lbl.Visibility = Visibility.Collapsed;
            iWeight_lbl.Visibility = Visibility.Collapsed;
            iMP_lbl.Visibility = Visibility.Collapsed;
            iST_lbl.Visibility = Visibility.Collapsed;
            iSSFR_lbl.Visibility = Visibility.Collapsed;
            iKBR_lbl.Visibility = Visibility.Collapsed;
            iGrapR_lbl.Visibility = Visibility.Collapsed;
            iKFR_lbl.Visibility = Visibility.Collapsed;
            iHEV_lbl.Visibility = Visibility.Collapsed;
            iHDR_lbl.Visibility = Visibility.Collapsed;
            iAtkSpeed_lbl.Visibility = Visibility.Collapsed;
            iCastSpeed_lbl.Visibility = Visibility.Collapsed;
            iMVS_lbl.Visibility = Visibility.Collapsed;
            iCrit_lbl.Visibility = Visibility.Collapsed;
            iExtraDamKama_lbl.Visibility = Visibility.Collapsed;
            iEDtA_lbl.Visibility = Visibility.Collapsed;
            iEAPa_lbl.Visibility = Visibility.Collapsed;
            iMPR_lbl.Visibility = Visibility.Collapsed;
            iHPR_lbl.Visibility = Visibility.Collapsed;
            iLuck_lbl.Visibility = Visibility.Collapsed;
            iEDH_lbl.Visibility = Visibility.Collapsed;
            iADtDemiH_lbl.Visibility = Visibility.Collapsed;
            iEDtAExcHumanAndDemi_lbl.Visibility = Visibility.Collapsed;
            iSpiritRage_lbl.Visibility = Visibility.Collapsed;
            iBidding_lbl.Visibility = Visibility.Collapsed;
            iEDtoBack_lbl.Visibility = Visibility.Collapsed;
            iHPRecoveryChance_lbl.Visibility = Visibility.Collapsed;
            iIgnoreResistance_lbl.Visibility = Visibility.Collapsed;
            iSpecialAttackED_lbl.Visibility = Visibility.Collapsed;
            iSpecialAttackEvRate_lbl.Visibility = Visibility.Collapsed;
            iHAP_lbl.Visibility = Visibility.Collapsed;
            iCastSpeedRate_lbl.Visibility = Visibility.Collapsed;
            iAtkSpeedRate_lbl.Visibility = Visibility.Collapsed;
            iAlchCookTime_lbl.Visibility = Visibility.Collapsed;
            iProcessingRate_lbl.Visibility = Visibility.Collapsed;
            iGathering_lbl.Visibility = Visibility.Collapsed;
            iFishing_lbl.Visibility = Visibility.Collapsed;
            iGathDropRate_lbl.Visibility = Visibility.Collapsed;
            iCombatEXP_lbl.Visibility = Visibility.Collapsed;
            iSkillEXP_lbl.Visibility = Visibility.Collapsed;
            iCHDamage_lbl.Visibility = Visibility.Collapsed;
            iAtkSpeedDmg_lbl.Visibility = Visibility.Collapsed;
            iEDtoAir_lbl.Visibility = Visibility.Collapsed;
            iEDtoCounter_lbl.Visibility = Visibility.Collapsed;
            iEDtoDown_lbl.Visibility = Visibility.Collapsed;
            iIgnoreGrapleResistance_lbl.Visibility = Visibility.Collapsed;
            iIgnoreKBResistance_lbl.Visibility = Visibility.Collapsed;
            iIgnoreKDResistance_lbl.Visibility = Visibility.Collapsed;
            iIgnoreStunResistance_lbl.Visibility = Visibility.Collapsed;
            iVisionRange_lbl.Visibility = Visibility.Collapsed;
            iMagicDR_lbl.Visibility = Visibility.Collapsed;
            iMelleDR_lbl.Visibility = Visibility.Collapsed;
            iRangeDR_lbl.Visibility = Visibility.Collapsed;
            iSiegeWeaponEvRate_lbl.Visibility = Visibility.Collapsed;
            iMagicAP_lbl.Visibility = Visibility.Collapsed;
            iMelleAP_lbl.Visibility = Visibility.Collapsed;
            iRangeAP_lbl.Visibility = Visibility.Collapsed;
            iJump_lbl.Visibility = Visibility.Collapsed;
            iFallDamage_lbl.Visibility = Visibility.Collapsed;
            iUnderwaterBreath_lbl.Visibility = Visibility.Collapsed;
            iMaxEnergy_lbl.Visibility = Visibility.Collapsed;


            Label[] Items_n = new Label[]
            {
            iAP_n,
            iAAP_n,
            iDP_n,
            iEvas_n,
            iAcc_n,
            iRes_n,
            iDR_n,
            iHP_n,
            iWeight_n,
            iMP_n,
            iST_n,
            iSSFR_n,
            iKBR_n,
            iGrapR_n,
            iKFR_n,
            iHEV_n,
            iHDR_n,
            iAtkSpeed_n,
            iCastSpeed_n,
            iMVS_n,
            iCrit_n,
            iExtraDamKama_n,
            iEDtA_n,
            iEAPa_n,
            iMPR_n,
            iHPR_n,
            iLuck_n,
            iEDH_n,
            iADtDemiH_n,
            iEDtAExcHumanAndDemi_n,
            iSpiritRage_n,
            iBidding_n,
            iEDtoBack_n,
            iHPRecoveryChance_n,
            iIgnoreResistance_n,
            iSpecialAttackED_n,
            iSpecialAttackEvRate_n,
            iHAP_n,
            iCastSpeedRate_n,
            iAtkSpeedRate_n,
            iAlchCookTime_n,
            iProcessingRate_n,
            iGathering_n,
            iFishing_n,
            iGathDropRate_n,
            iCombatEXP_n,
            iSkillEXP_n,
            iCHDamage_n,
            iAtkSpeedDmg_n,
            iEDtoAir_n,
            iEDtoCounter_n,
            iEDtoDown_n,
            iIgnoreGrapleResistance_n,
            iIgnoreKBResistance_n,
            iIgnoreKDResistance_n,
            iIgnoreStunResistance_n,
            iVisionRange_n,
            iMagicDR_n,
            iMelleDR_n,
            iRangeDR_n,
            iSiegeWeaponEvRate_n,
            iMagicAP_n,
            iMelleAP_n,
            iRangeAP_n,
            iJump_n,
            iFallDamage_n,
            iUnderwaterBreath_n,
            iMaxEnergy_n
        };
            Label[] Items_lbl = new Label[] 
            {
                iAP_lbl,
            iAAP_lbl,
            iDP_lbl,
            iEvas_lbl,
            iAcc_lbl,
            iRes_lbl,
            iDR_lbl,
            iHP_lbl,
            iWeight_lbl,
            iMP_lbl,
            iST_lbl,
            iSSFR_lbl,
            iKBR_lbl,
            iGrapR_lbl,
            iKFR_lbl,
            iHEV_lbl,
            iHDR_lbl,
            iAtkSpeed_lbl,
            iCastSpeed_lbl,
            iMVS_lbl,
            iCrit_lbl,
            iExtraDamKama_lbl,
            iEDtA_lbl,
            iEAPa_lbl,
            iMPR_lbl,
            iHPR_lbl,
            iLuck_lbl,
            iEDH_lbl,
            iADtDemiH_lbl,
            iEDtAExcHumanAndDemi_lbl,
            iSpiritRage_lbl,
            iBidding_lbl,
            iEDtoBack_lbl,
            iHPRecoveryChance_lbl,
            iIgnoreResistance_lbl,
            iSpecialAttackED_lbl,
            iSpecialAttackEvRate_lbl,
            iHAP_lbl,
            iCastSpeedRate_lbl,
            iAtkSpeedRate_lbl,
            iAlchCookTime_lbl,
            iProcessingRate_lbl,
            iGathering_lbl,
            iFishing_lbl,
            iGathDropRate_lbl,
            iCombatEXP_lbl,
            iSkillEXP_lbl,
            iCHDamage_lbl,
            iAtkSpeedDmg_lbl,
            iEDtoAir_lbl,
            iEDtoCounter_lbl,
            iEDtoDown_lbl,
            iIgnoreGrapleResistance_lbl,
            iIgnoreKBResistance_lbl,
            iIgnoreKDResistance_lbl,
            iIgnoreStunResistance_lbl,
            iVisionRange_lbl,
            iMagicDR_lbl,
            iMelleDR_lbl,
            iRangeDR_lbl,
            iSiegeWeaponEvRate_lbl,
            iMagicAP_lbl,
            iMelleAP_lbl,
            iRangeAP_lbl,
            iJump_lbl,
            iFallDamage_lbl,
            iUnderwaterBreath_lbl,
            iMaxEnergy_lbl
            };
            Thickness[] lbl_thk = new Thickness[12] { new Thickness(5, 0, 0, 0), new Thickness(5, 26, 0, 0), new Thickness(5, 52, 0, 0), new Thickness(5, 78, 0, 0), new Thickness(5, 104, 0, 0), new Thickness(5, 130, 0, 0), new Thickness(5, 156, 0, 0), new Thickness(5, 181, 0, 0), new Thickness(5, 205, 0, 0), new Thickness(5, 231, 0, 0), new Thickness(5, 257, 0, 0), new Thickness(5, 283, 0, 0) };
            Thickness[] n_thk = new Thickness[12] { new Thickness(279, 0, 0, 0), new Thickness(279, 26, 0, 0), new Thickness(279, 52, 0, 0), new Thickness(279, 78, 0, 0), new Thickness(279, 104, 0, 0), new Thickness(279, 130, 0, 0), new Thickness(279, 156, 0, 0), new Thickness(279, 181, 0, 0), new Thickness(279, 205, 0, 0), new Thickness(279, 231, 0, 0), new Thickness(279, 257, 0, 0), new Thickness(279, 283, 0, 0) };
            int[] Items = new int[] 
            {
            cs.iAP,
            cs.iAAP,
            cs.iDP,
            cs.iEvas,
            cs.iAcc,
            cs.iRes ,
            cs.iDR,
            cs.iHP,
            cs.iWeight,
            cs.iMP,
            cs.iST,
            cs.iSSFR ,
            cs.iKBR ,
            cs.iGrapR ,
            cs.iKFR ,
            cs.iHEV,
            cs.iHDR,
            cs.iAtkSpeed,
            cs.iCastSpeed,
            cs.iMVS,
            cs.iCrit,
            cs.iExtraDamKama,
            cs.iEDtA,
            cs.iEAPa,
            cs.iMPR,
            cs.iHPR,
            cs.iLuck,
            cs.iEDH,
            cs.iADtDemiH,
            cs.iEDtAExcHumanAndDemi,
            cs.iSpiritRage ,
            cs.iBidding ,
            cs.iEDtoBack ,
            cs.iHPRecoveryChance,
            cs.iIgnoreResistance ,
            cs.iSpecialAttackED ,
            cs.iSpecialAttackEvRate ,
            cs.iHAP,
            cs.iCastSpeedRate ,
            cs.iAtkSpeedRate ,
            Convert.ToInt32(cs.iAlchCookTime),
            cs.iProcessingRate ,
            cs.iGathering,
            cs.iFishing,
            cs.iGathDropRate ,
            cs.iCombatEXP ,
            cs.iSkillEXP ,
            cs.iCHDamage ,
            cs.iAtkSpeedDmg ,
            cs.iEDtoAir ,
            cs.iEDtoCounter ,
            cs.iEDtoDown ,
            cs.iIgnoreGrapleResistance ,
            cs.iIgnoreKBResistance ,
            cs.iIgnoreKDResistance ,
            cs.iIgnoreStunResistance ,
            cs.iVisionRange,
            cs.iMagicDR,
            cs.iMelleDR,
            cs.iRangeDR,
            cs.iSiegeWeaponEvRate ,
            cs.iMagicAP,
            cs.iMelleAP,
            cs.iRangeAP,
            cs.iJump,
            cs.iFallDamage,
            cs.iUnderwaterBreath,
            cs.iMaxEnergy
            };
            int PositionCheck = 0;


            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] != 0)
                {
                    Items_lbl[i].Margin = lbl_thk[PositionCheck];
                    Items_n[i].Margin = n_thk[PositionCheck];
                    Items_lbl[i].Visibility = Visibility.Visible;
                    Items_n[i].Visibility = Visibility.Visible;

                    if(PositionCheck <= 11) PositionCheck++;
                }
            }
        }

        private void ResistanceStateLabels()
        {
            ResistanceStatsExp.Margin = new Thickness(610, AdditionalStateExp.Height + 5, 0, 141 + (343 - AdditionalStateExp.Height));

        }
    }
}
