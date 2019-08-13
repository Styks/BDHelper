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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BDHelper
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string sclass = "None";
        string chWeapon = "None";
        string chSubWeapon = "None";
        Brush cimg;
        
        private void GearForm_btn_Click(object sender, RoutedEventArgs e)
        {
            Gear g = new Gear
            {
                sclass = sclass,
                chWeapon = chWeapon,
                chSubWeapon = chSubWeapon
            };
            Brush cimg = Cimg_img.Fill;
            g.cimg = cimg;
            Hide();
            g.Show();
        }

        private void Warrior_btn_Click(object sender, RoutedEventArgs e)
        {
            cimg = Warrior_btn.Background;
            Cimg_img.Fill = cimg;
            sclass = "Warrior";
            Sclass_lbl.Content = sclass;
            chWeapon = "Longsword";
            chSubWeapon = "Shield";
        }

        private void Sorceress_btn_Click(object sender, RoutedEventArgs e)
        {
            cimg = Sorceress_btn.Background;
            Cimg_img.Fill = cimg;
            sclass = "Sorceress";
            Sclass_lbl.Content = sclass;
            chWeapon = "Amulet";
            chSubWeapon = "Talisman";

        }

        private void Berserker_btn_Click(object sender, RoutedEventArgs e)
        {
            cimg = Berserker_btn.Background;
            Cimg_img.Fill = cimg;
            sclass = "Berserker";
            Sclass_lbl.Content = sclass;
            chWeapon = "Axe";
            chSubWeapon = "Ornamental Knot";

        }

        private void Ranger_btn_Click(object sender, RoutedEventArgs e)
        {
            cimg = Ranger_btn.Background;
            Cimg_img.Fill = cimg;
            sclass = "Ranger";
            Sclass_lbl.Content = sclass;
            chWeapon = "Longbow";
            chSubWeapon = "Dagger";
        }

        private void Tamer_btn_Click(object sender, RoutedEventArgs e)
        {
            cimg = Tamer_btn.Background;
            Cimg_img.Fill = cimg;
            sclass = "Tamer";
            Sclass_lbl.Content = sclass;
            chWeapon = "Shortsword";
            chSubWeapon = "Trinket";

        }

        private void Valkyrie_btn_Click(object sender, RoutedEventArgs e)
        {
            cimg = Valkyrie_btn.Background;
            Cimg_img.Fill = cimg;
            sclass = "Valkyrie";
            Sclass_lbl.Content = sclass;
            chWeapon = "Longsword";
            chSubWeapon = "Shield";
        }

        private void Musa_btn_Click(object sender, RoutedEventArgs e)
        {
            cimg = Musa_btn.Background;
            Cimg_img.Fill = cimg;
            sclass = "Musa";
            Sclass_lbl.Content = sclass;
            chWeapon = "Blade";
            chSubWeapon = "Horn Bow";

        }

        private void Maehwa_btn_Click(object sender, RoutedEventArgs e)
        {
            cimg = Maehwa_btn.Background;
            Cimg_img.Fill = cimg;
            sclass = "Maehwa";
            Sclass_lbl.Content = sclass;
            chWeapon = "Blade";
            chSubWeapon = "Horn Bow";
        }

        private void Witch_btn_Click(object sender, RoutedEventArgs e)
        {
            cimg = Witch_btn.Background;
            Cimg_img.Fill = cimg;
            sclass = "Witch";
            Sclass_lbl.Content = sclass;
            chWeapon = "Staff";
            chSubWeapon = "Dagger";


        }

        private void Wizard_btn_Click(object sender, RoutedEventArgs e)
        {
            cimg = Wizard_btn.Background;
            Cimg_img.Fill = cimg;
            sclass = "Wizard";
            Sclass_lbl.Content = sclass;
            chWeapon = "Staff";
            chSubWeapon = "Dagger";

        }

        private void Kunoichi_btn_Click(object sender, RoutedEventArgs e)
        {
            cimg = Kunoichi_btn.Background;
            Cimg_img.Fill = cimg;
            sclass = "Kunoichi";
            Sclass_lbl.Content = sclass;
            chWeapon = "Shortsword";
            chSubWeapon = "Kunai and Shuriken";

        }

        private void Ninja_btn_Click(object sender, RoutedEventArgs e)
        {
            cimg = Ninja_btn.Background;
            Cimg_img.Fill = cimg;
            sclass = "Ninja";
            Sclass_lbl.Content = sclass;
            chWeapon = "Shortsword";
            chSubWeapon = "Kunai and Shuriken";
        }

        private void DK_btn_Click(object sender, RoutedEventArgs e)
        {
            cimg = DK_btn.Background;
            Cimg_img.Fill = cimg;
            sclass = "Dark Knight";
            Sclass_lbl.Content = sclass;
            chWeapon = "Kriegmesser";
            chSubWeapon = "Ornamental Knot";
        }

        private void Striker_btn_Click(object sender, RoutedEventArgs e)
        {
            cimg = Striker_btn.Background;
            Cimg_img.Fill = cimg;
            sclass = "Striker";
            Sclass_lbl.Content = sclass;
            chWeapon = "Gauntlet";
            chSubWeapon = "Vambrace";
        }

        private void Mystic_btn_Click(object sender, RoutedEventArgs e)
        {
            cimg = Mystic_btn.Background;
            Cimg_img.Fill = cimg;
            sclass = "Mystic";
            Sclass_lbl.Content = sclass;
            chWeapon = "Gauntlet";
            chSubWeapon = "Vambrace";
        }

        private void Lahn_btn_Click(object sender, RoutedEventArgs e)
        {
            cimg = Lahn_btn.Background;
            Cimg_img.Fill = cimg;
            sclass = "Lahn";
            Sclass_lbl.Content = sclass;
            chWeapon = "Crescent Pendulum";
            chSubWeapon = "Noble Sword";
        }

        private void Archer_btn_Click(object sender, RoutedEventArgs e)
        {
            cimg = Archer_btn.Background;
            Cimg_img.Fill = cimg;
            sclass = "Archer";
            Sclass_lbl.Content = sclass;
            chWeapon = "Crossbow";
            chSubWeapon = "Ra'ghon";

        }

        private void Shai_btn_Click(object sender, RoutedEventArgs e)
        {
            cimg = Shai_btn.Background;
            Cimg_img.Fill = cimg;
            sclass = "Shai";
            Sclass_lbl.Content = sclass;
            chWeapon = "Florang";
            chSubWeapon = "Vitclari";
        }



        /*    private void SkillTreeForm_btn_Click(object sender, EventArgs e)
            {
                SkillTreeForm stf = new SkillTreeForm
                {
                    sclass = sclass
                };
                Image cimg = Cimg_pb.BackgroundImage;
                stf.cimg = cimg;
                Hide();
                if (stf.ShowDialog() == DialogResult.Cancel)
                {
                    Show();
                    stf.Close();
                }
            } */

        /*     private void BuffTimerForm_btn_Click(object sender, EventArgs e)
             {
                 TimerForm tf = new TimerForm
                 {

                 };

                 Hide();
                 if (tf.ShowDialog() == DialogResult.Cancel)
                 {
                     Show();
                     tf.Close();
                 }
             } */


    }
}
