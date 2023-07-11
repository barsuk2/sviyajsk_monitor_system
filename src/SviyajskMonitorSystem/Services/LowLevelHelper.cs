using Microsoft.AspNetCore.Html;
using Microsoft.EntityFrameworkCore;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models;
using SviyajskMonitorSystem.Models.DataViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Services
{
    public class LowLevelHelper
    {


        public static string GetHtmlString(IHtmlContent content)
        {
            var writer = new System.IO.StringWriter();
            content.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }






        public static string AttributeTypeToRussianString(AttributeTypes type)
        {
            switch (type)
            {
                case AttributeTypes.stringval:return "Строка";
                case AttributeTypes.intval:return "Целое число";
                case AttributeTypes.floatval:return "Вещественное число";
                case AttributeTypes.Choosable:return "Значение из справочника";
                case AttributeTypes.photo:return "Фотографии";
                case AttributeTypes.elements:return "Материальные объекты";
                default:return "Значения нет в списке зарегистрированных типов";
            }
        }

        public static bool MassDoleFilterHelper(List<ChemistryElMassDole> massdoles, ChemistryElementFilterModel fm)
        {
            if (fm.needrange)
            {
                ChemistryElMassDole dole = massdoles.FirstOrDefault(md => md.Chelement.id == fm.element.id && md.Value >= fm.minvalue && md.Value <= fm.maxvalue);
                if (dole == null) { return false; } else { return true; }
            }
            else
            {
                ChemistryElMassDole dole = massdoles.FirstOrDefault(md => md.Chelement.id == fm.element.id && md.Value > 0);
                if (dole == null) { return false; } else { return true; }
            }
        }

        //Convert String to AanlyzeType
        public static AnalyzeType StringToAnTypeConverter(string s)
        {

            AnalyzeType type = AnalyzeType.DendroChronologicalAnalyzes;
            switch (s)
            {
                case "mban": type = AnalyzeType.MicroBiologicalAnalyzes; break;
                case "dclan": type = AnalyzeType.DendroChronologicalAnalyzes; break;
                case "rfan": type = AnalyzeType.rentgenfluoriscentnyi; break;

                default:
                    break;
            }
            return type;
        }

        public static string getparent(ApplicationDbContext context, int id, string s)
        {
            Element element = context.Element.Include(el => el.Parent).FirstOrDefault(el => el.Id == id);
            if (element.Parent != null)
            {
                id = element.Parent.Id;
                string str = element.Parent.Name;
                s = str + ", " + s;
                s = getparent(context, id, s);
            }
            return s;

        }

        public static string GetAllParents(ApplicationDbContext context, int id)
        {
            string s = context.Element.FirstOrDefault(el => el.Id == id).Name;
            s = getparent(context, id, s);
            return s;
        }


        public static string GeneratePassword(int length)
        {
            Random rnd = new Random();
            char[] password = new char[length];
            int maxnum = rnd.Next(1, 4);
            int maxpunct = rnd.Next(1, 3);
            int maxupcase = rnd.Next(1, 5);
            int maxlower = length - maxnum - maxpunct - maxupcase;
            int currnum = 0;
            int currpunct = 0;
            int curruper = 0;
            int currlower = 0;
            PasswordParts[] parts = new PasswordParts[length];
            //this loop sets positions of symvol types in password
            for (int i = 0; i < length; i++)
            {
                bool neednewvalue = true;
                while (neednewvalue)
                {
                    int k = rnd.Next(4);//for set type of password letter
                    switch (k)
                    {
                        case 0:
                            if (curruper < maxupcase)
                            {
                                parts[i] = PasswordParts.Upercase;
                                curruper++;
                                neednewvalue = false;
                            }
                            break;
                        case 1:
                            if (currlower < maxlower)
                            {
                                parts[i] = PasswordParts.Lowercase;
                                currlower++;
                                neednewvalue = false;
                            }
                            break;
                        case 2:
                            if (currnum < maxnum)
                            {
                                parts[i] = PasswordParts.Number;
                                currnum++;
                                neednewvalue = false;
                            }
                            break;
                        case 3:
                            if (currpunct < maxpunct)
                            {
                                parts[i] = PasswordParts.Punctuation;
                                currpunct++;
                                neednewvalue = false;
                            }
                            break;
                    }
                }

            }
            //this loop generates password
            for (int i = 0; i < length; i++)
            {
                password[i] = GenerateSymvol(rnd, parts[i]);
            }
            return new string(password);

        }



        #region password Generator functions

        private static char GenerateSymvol(Random rnd, PasswordParts type)
        {
            switch (type)
            {
                case PasswordParts.Lowercase: return GetRandomLowerCase(rnd);
                case PasswordParts.Upercase: return GetRandomUpperCase(rnd);
                case PasswordParts.Number: return GetRandomNumber(rnd);
                case PasswordParts.Punctuation: return GetRandomPunctuation(rnd);
            }
            return '_';//returns if not cases// this code string never run
        }


        private static char GetRandomNumber(Random rnd)
        {
            string nums = "0123456789";
            int pos = rnd.Next(nums.Length);
            return nums[pos];
        }

        private static char GetRandomLowerCase(Random rnd)
        {
            int num = rnd.Next(26);

            return (char)('a' + num);
        }
        private static char GetRandomUpperCase(Random rnd)
        {
            int num = rnd.Next(26);

            return (char)('A' + num);
        }
        private static char GetRandomPunctuation(Random rnd)
        {
            string nums = "?!@#$%&*";
            int pos = rnd.Next(nums.Length);
            return nums[pos];
        }
        #endregion



    }
    public enum PasswordParts
    {
        Upercase,
        Lowercase,
        Number,
        Punctuation
    }
}