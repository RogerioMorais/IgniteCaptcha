using SixLabors.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RMorais.IgniteCaptcha.Descriptions
{
    public enum FontsName { Arial, Verdana, TimesNewRoman };
    public struct Fonts {
        public static string GetName(FontsName param) {
            return GetName((int)param);
        }
        public static string GetName(int param)
        {
            string result = "Arial";
            switch (param)
            {
                case (int)FontsName.Arial:
                    break;
                case (int)FontsName.Verdana:
                    result = "Verdana";
                    break;
                case (int)FontsName.TimesNewRoman:
                    result = "Times New Roman";
                    break;
            }

            return result;
        }
        public static SixLabors.Fonts.FontStyle GetStyle(int paran)
        {
            SixLabors.Fonts.FontStyle result = SixLabors.Fonts.FontStyle.Regular;
            switch (paran) {
                case (int)SixLabors.Fonts.FontStyle.Regular:
                    break;
                case (int)SixLabors.Fonts.FontStyle.Bold:
                    result = SixLabors.Fonts.FontStyle.Bold;
                    break;
                case (int)SixLabors.Fonts.FontStyle.Italic:
                    result = SixLabors.Fonts.FontStyle.Italic;
                    break;
                case (int)SixLabors.Fonts.FontStyle.BoldItalic:
                    result = SixLabors.Fonts.FontStyle.BoldItalic;
                    break;
            }

            return result;

        }
    }


    public struct CaptchaAtribute {
        public CaptchaAtribute(WriteLine[] lines, WriteCaractere[] caracteres) {
            this.Lines = lines;
            this.Caracteres = caracteres;
        }

        public WriteLine[] Lines { get; }
        public WriteCaractere[] Caracteres { get; }
        public string CaptchaValue {
            get {
                string result="";
                foreach (WriteCaractere l in this.Caracteres) {
                    result=string.Concat(result,l.Caracter);
                }
                return result;
            }

        }

    }

    public struct WriteLine{
        public WriteLine(PointF[] points)
        {
            this.Points = points;
            this.LineSize = 0;
            this.Color = SixLabors.ImageSharp.Rgba32.Black;
        }
        public SixLabors.ImageSharp.Rgba32 Color { get; set; }
        public PointF[] Points { get; }
        public int LineSize { get; set; }

    }

    public struct WriteCaractere
    {
        public SixLabors.ImageSharp.Rgba32 Color { get; set; }
        public PointF Point { get; set; }
        public int FontSize { get; set; }
        public string Caracter { get; set; }
        public string FontName { get; set; }
        public SixLabors.Fonts.FontStyle Style{get;set;}
    }


}
