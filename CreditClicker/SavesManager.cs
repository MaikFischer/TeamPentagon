using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreditClicker
{
    public static class SavesManager
    {
        private static List<Save> savesList = new List<Save>();

        public static int currentSaveId { get; set; } = 1;

        public static void registerSave(Save save)
        {
            foreach(Save s in savesList)
            {
                if (s.id == save.id)
                {
                    savesList.Remove(s);
                    savesList.Add(save);
                }else
                {
                    savesList.Add(save);
                }
            }
        }

        public static void unregisterSave(int saveId)
        {
            foreach(Save s in savesList)
            {
                if (s.id == saveId) savesList.Remove(s);
            }
        }

        public static void saveAllStates()
        {
            MessageBox.Show("test");
            foreach(Save save in savesList)
            {
                saveState(save);
                
            }
        }

        public static void saveState(Save save)
        {
            if (File.Exists("C:/CreditClicker/Saves/save" + save.id + ".txt"))
            {
                DialogResult result = MessageBox.Show("There is already a saved game in this slot. Do you want to overwrite it?", "SLOT COVERED", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (StreamWriter sw = new StreamWriter("C:/CreditClicker/Saves/save" + save.id + ".txt"))
                    {
                        sw.WriteLine(save.score);
                        sw.WriteLine(save.bonus);
                        sw.WriteLine(save.multiplier);
                        sw.WriteLine(save.passiveBonus);
                        foreach (Item item in save.items)
                        {
                            sw.WriteLine(item.getName());
                        }
                    }
                }
            }else
            {
                Directory.CreateDirectory("C:/CreditClicker/Saves/");
                using (StreamWriter sw = new StreamWriter("C:/CreditClicker/Saves/save" + save.id + ".txt"))
                {
                    sw.WriteLine(save.score);
                    sw.WriteLine(save.bonus);
                    sw.WriteLine(save.multiplier);
                    sw.WriteLine(save.passiveBonus);
                    foreach (Item item in save.items)
                    {
                        sw.WriteLine(item.getName());
                    }
                }
            }
        }

        public static void getSaves()
        {
            for(int saveId = 1; saveId < 5;saveId++)
            {
                Save save = null;
                if (File.Exists("C:/CreditClicker/Saves/save" + saveId + ".txt"))
                {
                    string[] lines = File.ReadAllLines("C:/CreditClicker/Saves/save" + saveId + ".txt");
                    if (lines != null)
                    {
                        save.score = Double.Parse(lines[0]);
                        save.bonus = Int32.Parse(lines[1]);
                        save.multiplier = Int32.Parse(lines[2]);
                        save.passiveBonus = Double.Parse(lines[3]);
                        if (lines[4] != null)
                        {
                            for (int i = 4; i < lines.Length; i++)
                            {
                                switch (lines[i])
                                {
                                    case "CheatSheet":
                                        save.items.Add(new Item("CheatSheet", 1, 0, 150));
                                        break;
                                    case "StudyGroup":
                                        save.items.Add(new Item("StudyGroup", 3, 0, 250));
                                        break;
                                    case "ConsultationHour":
                                        save.items.Add(new Item("ConsultationHour", 0, 2, 2500));
                                        break;
                                    case "OldExam":
                                        save.items.Add(new Item("OldExam", 10, 0, 5000));
                                        break;
                                    case "Insider":
                                        save.items.Add(new Item("Insider", 0, 4, 15000));
                                        break;
                                }
                            }
                        }
                        savesList.Add(save);
                    }
                }
            }
        }
    }
}
