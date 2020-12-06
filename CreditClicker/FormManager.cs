using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreditClicker
{
    public static class FormManager
    {

        private static List<Form> formList = new List<Form>();

        public static Color DEFAULT_COLOR = Color.DarkOrange;

        public static Image DEFAULT_IMAGE = global::CreditClicker.Properties.Resources.backgroundanimated;
        public static Color currentAllColor { get; set; }  = Color.DarkOrange;
        public static Color currentButtonColor { get; set; }  = Color.DarkOrange;
        public static Color currentButtonTextColor { get; set; } = Color.Black;
        public static Color currentCommonTextColor { get; set; }  = Color.DarkOrange;
        public static Color currentSpecialTextColor { get; set; } = Color.White;

        public static Color currentBackgroundColor { get; set; } = Color.Black;

        public static string currentBackgroundImage;

        public static void registerForm(Form form)
        {
            if (!formList.Contains(form)) formList.Add(form);
        }

        public static void unRegisterForm(Form form)
        {
            if (formList.Contains(form)) formList.Remove(form);
        }

        public static void initAllColors()
        {
            changeCommonTextColor(currentCommonTextColor);
            changeSpecialTextColor(currentSpecialTextColor);
            changeButtonColor(currentButtonColor);
            changeButtonTextColor(currentButtonTextColor);
        }


       /* public static void setAllColors(Color color)
        {
            foreach (Form form in formList)
            {
                foreach (Control c in form.Controls)
                {
                    if (c.GetType() == typeof(Panel))
                    {
                        foreach (Panel p in form.Controls)
                        {
                            foreach (Control con in p.Controls)
                            {
                                if (con.ForeColor != Color.White && con.ForeColor != Color.Transparent)
                                {
                                    if (con.GetType() == typeof(Button))
                                    {
                                        con.BackColor = color;
                                    }
                                    else
                                    {
                                        con.ForeColor = color;
                                    }
                                }
                            }
                        }
                    }
                    else if (c.ForeColor != Color.White && c.ForeColor != Color.Transparent)
                    {
                        if (c.GetType() == typeof(Button))
                        {
                            c.BackColor = color;
                        }
                        else
                        {
                            c.ForeColor = color;
                        }
                    }
                }
            }
            currentAllColor = color;
        }*/

        public static void changeButtonColor(Color color)
        {
            foreach(Form form in formList)
            {
                foreach (Control c in form.Controls)
                {
                    //Falls das Form Panel beinhaltet
                    if (c.GetType() == typeof(Panel))
                    {
                        foreach (Panel p in form.Controls)
                        {
                            foreach (Control control in p.Controls)
                            {
                                if (control.GetType() == typeof(Button))
                                {
                                    control.BackColor = color;
                                }
                            }
                        }
                    }
                    else if (c.GetType() == typeof(Button))
                    {
                        c.BackColor = color;
                    }
                }
            }
            currentButtonColor = color;
        }

        public static void changeButtonTextColor(Color color)
        {
            foreach(Form form in formList)
            {
                foreach (Control c in form.Controls)
                {
                    //Falls das Form Panel beinhaltet
                    if (c.GetType() == typeof(Panel))
                    {
                        foreach (Panel p in form.Controls)
                        {
                            foreach (Control control in p.Controls)
                            {
                                if (control.GetType() == typeof(Button) && !control.Text.StartsWith("$"))
                                {
                                    control.ForeColor = color;
                                }
                            }
                        }
                    }
                    else if (c.GetType() == typeof(Button) && !c.Text.StartsWith("$"))
                    {
                        c.ForeColor = color;
                    }

                }
            }
            currentButtonTextColor = color;
        }

        public static void changeCommonTextColor(Color color)
        {
            foreach(Form form in formList)
            {
                foreach (Control c in form.Controls)
                {
                    if (c.GetType() == typeof(Panel))
                    {
                        foreach (Panel p in form.Controls)
                        {
                            foreach (Control control in p.Controls)
                            {
                                if (control.GetType() == typeof(Label) ||  control.GetType() == typeof(CheckBox))
                                {
                                    if (control.ForeColor == currentCommonTextColor)
                                    {
                                        control.ForeColor = color;
                                    } 
                                }
                            }
                        }
                    }
                    else if (c.GetType() == typeof(Label) || c.GetType() == typeof(CheckBox))
                    {
                        if (c.ForeColor == currentCommonTextColor)
                        {
                            c.ForeColor = color;
                        }
                    }
                }
            }
            currentCommonTextColor = color;
        }

        public static void changeSpecialTextColor(Color color)
        {
            foreach(Form form in formList)
            {
                foreach (Control c in form.Controls)
                {
                    if (c.GetType() == typeof(Panel))
                    {
                        foreach (Panel p in form.Controls)
                        {
                            foreach (Control control in p.Controls)
                            {
                                if (control.GetType() == typeof(Label) && control.ForeColor == currentSpecialTextColor)
                                {
                                    control.ForeColor = color;
                                }
                            }
                        }
                    }
                    else if (c.GetType() == typeof(Label) && c.ForeColor == currentSpecialTextColor)
                    {
                        c.ForeColor = color;
                    }
                }
            }
            currentSpecialTextColor = color;
        }

        public static void changeBackgroundColor(Color color)
        {
            foreach(Form form in formList)
            {
                foreach(Control c in form.Controls)
                {
                    if (c.GetType() == typeof(Panel))
                    {
                        foreach (Panel p in form.Controls)
                        {
                            foreach (Control control in p.Controls)
                            {
                                if (control.GetType() == typeof(PictureBox) && !control.Name.Contains("Area"))
                                {
                                    control.Visible = false;
                                    form.BackgroundImage = null;
                                    form.BackColor = color;
                                }
                            }
                        }
                    }
                    else if (c.GetType() == typeof(PictureBox) && !c.Name.Contains("Area"))
                    {
                        c.Visible = false;
                        form.BackgroundImage = null;
                        form.BackColor = color;
                    }
                }
            }
            currentBackgroundColor = color;
        }

        public static void changeBackgroundImage(String image)
        {
            foreach (Form form in formList)
            {
                foreach (Control c in form.Controls)
                {
                    if (c.GetType() == typeof(Panel))
                    {
                        foreach (Panel p in form.Controls)
                        {
                            foreach (Control control in p.Controls)
                            {
                                
                                if (control.GetType() == typeof(PictureBox) && !control.Name.Contains("Area") && !control.Name.StartsWith("icon"))
                                {
                                    control.Visible = false;
                                    Console.WriteLine(image);
                                    form.BackgroundImage = Image.FromFile(image);
                                    form.BackColor = Color.Black;
                                }
                            }
                        }
                    }
                    else 
                    {
                        if (c.GetType() == typeof(PictureBox) && !c.Name.Contains("Area") && !c.Name.StartsWith("icon"))
                        {
                            c.Visible = false;
                            form.BackgroundImage = Image.FromFile(image);
                            form.BackColor = Color.Black;
                        }
                        
                    }
                }
                currentBackgroundImage = image;
            }
        }

        public static void resetBackgroundImage()
        {
            foreach (Form form in formList)
            {
                foreach (Control c in form.Controls)
                {
                    if (c.GetType() == typeof(Panel))
                    {
                        foreach (Panel p in form.Controls)
                        {
                            foreach (Control control in p.Controls)
                            {

                                if (control.GetType() == typeof(PictureBox) && !control.Name.Contains("Area") && !control.Name.StartsWith("icon"))
                                {
                                    control.Visible = true;
                                    form.BackgroundImage = DEFAULT_IMAGE;
                                    form.BackColor = Color.Black;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (c.GetType() == typeof(PictureBox) && !c.Name.Contains("Area") && !c.Name.StartsWith("icon"))
                        {
                            c.Visible = true;
                            form.BackgroundImage = DEFAULT_IMAGE;
                            form.BackColor = Color.Black;
                        }

                    }
                }
            }
        }

    }

  

    
}
