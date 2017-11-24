using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMorais.IgniteCaptcha.Descriptions;
using RMorais.IgniteCaptcha;

namespace UnitTestCaptha
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MinFontName() {
           Assert.AreEqual("Arial", RMorais.IgniteCaptcha.Descriptions.Fonts.GetName(0));
        }
        [TestMethod]
        [Description("If you use a value out side of range, the method return default value \"Arial\"")]
        public void LessMinFontName()
        {
            Assert.AreEqual("Arial", RMorais.IgniteCaptcha.Descriptions.Fonts.GetName(-1));
        }

        [TestMethod]
        public void MaxFontName()
        {
            Assert.AreEqual("Times New Roman", RMorais.IgniteCaptcha.Descriptions.Fonts.GetName(2));
        }
        [TestMethod]
        [Description("If you use a value out side of range, the method return default value \"Arial\"")]
        public void OverMaxFontName()
        {
            Assert.AreEqual("Arial", RMorais.IgniteCaptcha.Descriptions.Fonts.GetName(3));
        }


        [TestMethod]
        public void MinStyle()
        {
            Assert.AreEqual(SixLabors.Fonts.FontStyle.Regular, RMorais.IgniteCaptcha.Descriptions.Fonts.GetStyle(0));
        }
        [TestMethod]
        [Description("If you use a value out side of range, the method return default value \"Arial\"")]
        public void LessMinStyle()
        {
            Assert.AreEqual(SixLabors.Fonts.FontStyle.Regular, RMorais.IgniteCaptcha.Descriptions.Fonts.GetStyle(0));
        }

        [TestMethod]
        public void MaxStyle()
        {
            Assert.AreEqual(SixLabors.Fonts.FontStyle.BoldItalic, RMorais.IgniteCaptcha.Descriptions.Fonts.GetStyle(3));
        }
        [TestMethod]
        [Description("If you use a value out side of range, the method return default value \"Arial\"")]
        public void OverMaxStyle()
        {
            Assert.AreEqual(SixLabors.Fonts.FontStyle.Regular, RMorais.IgniteCaptcha.Descriptions.Fonts.GetStyle(4));
        }

        [TestMethod]
        public void CaptchaValue()
        {
            WriteCaractere[] caracteres = new WriteCaractere[]
            {
                new WriteCaractere(){Caracter="T"},
                new WriteCaractere(){Caracter="e"},
                new WriteCaractere(){Caracter="s"},
                new WriteCaractere(){Caracter="t"},
                new WriteCaractere(){Caracter="s"}

            };
            CaptchaAtribute cpt =new CaptchaAtribute(new WriteLine[5], caracteres);
            Assert.AreEqual("Tests", cpt.CaptchaValue);
        }

        [TestMethod]
        public void MinGetColor()
        {
            Assert.AreEqual(SixLabors.ImageSharp.Rgba32.AliceBlue,IgniteCaptcha.GetColor(0));
         }

        [TestMethod]
        public void MaxGetColor()
        {
            Assert.AreEqual(SixLabors.ImageSharp.Rgba32.YellowGreen, IgniteCaptcha.GetColor(141));
        }

        [TestMethod]
        public void LessMinGetColor()
        {
            Assert.ThrowsException<System.IndexOutOfRangeException>(
            () => { IgniteCaptcha.GetColor(-1); });
        }

        [TestMethod]
        public void OverMaxGetColor()
        {
            Assert.ThrowsException<System.IndexOutOfRangeException>(
                () => { IgniteCaptcha.GetColor(142); });
        }

    }
}
