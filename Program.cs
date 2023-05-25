using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace lab16_OOP
{
    internal static class Program
    {
        public static CycledList<Engine> list = new CycledList<Engine>();
        public static int grouping = 0;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        public static void  PrintCollection(CycledList<Engine> engines, Form1 form)
        {
            int weight = 0;
            int count = 1;
            IEnumerable<Engine> ans = new List<Engine>();
            switch ((Enums.AddMenu)grouping)
            {
                case Enums.AddMenu.Engine:
                    {
                        ans = from engine in engines where engine is Engine select engine;
                        break;
                    }
                case Enums.AddMenu.InternalCombustionEngine:
                    {
                        ans = from engine in engines where engine is InternalCombustionEngine select engine;
                        break;
                    }
                case Enums.AddMenu.DiselEngine:
                    {
                        ans = from engine in engines where engine is DiselEngine select engine;
                        break;
                    }
                case Enums.AddMenu.TurbojetEngine:
                    {
                        ans = from engine in engines where engine is TurbojetEngine select engine;
                        break;
                    }
                default:
                    {
                        ans = from engine in engines select engine;
                        break;
                    }
            }
            if (IsInt(form.WeightFilter.Text))
            {
                weight = Int32.Parse(form.WeightFilter.Text);
                ans = from engine in ans where new Regex("^" + weight.ToString()).IsMatch(engine.Weight.ToString()) select engine;
            }
            if (form.sorting.Checked == true)
            {
                ans = ans.OrderBy(x => x.Weight);
            }
            form.mainTextBox.Clear();
            form.mainTextBox.Text = "[\r\n";
            foreach (var engine in ans)
            {
                form.mainTextBox.Text += "  " + list.FindIndex((Engine t1, Engine t2) => t1.Weight == t2.Weight, engine) + "\t" + engine.ToString() + "\r\n";
                count++;
            }
            form.mainTextBox.Text += "]\r\n";
        }
        public static bool IsInt(string line)
        {
            Regex reg = new Regex("^[1234567890]+$");
            if (reg.IsMatch(line))
            {
                return true;
            }
            return false;
        }
    }
}