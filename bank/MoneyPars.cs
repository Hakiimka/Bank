using System.Collections.Generic;

namespace bank
{
    class MoneyPars
    {

        ParsGetHTML test;
        List<string> money = new List<string>();

        public MoneyPars(ParsGetHTML html)
        {
            test = html;
        }

        public List<string> GetMoneyInfo()
        {
            int index = 0;
            List<string> listbox = new List<string>();
            listbox.Add("Доллар");
            listbox.Add("Евро");
            listbox.Add("Юань");
            listbox.Add("Гривна");
            listbox.Add("Тенге");
            string space = " ";
            string html = test.HTMLtext;

            while (index != -1)
            {
                index = html.IndexOf("<div class=\"cbcourses__value\">"); // poisk
                if (index != -1)
                {
                    html = html.Remove(0, index + 30);
                    money.Add(html.Remove(html.IndexOf("<")));
                }

            }
            //***********************************************
            for (int i = 0; i < listbox.Count; i++)
            {
                listbox[i] += space + money[i];
            }

            return listbox;
        }
    }
}
