using System;
using System.Numerics;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Brushes;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using SixLabors.Shapes;
using RMorais.IgniteCaptcha.Descriptions;
using System.Linq;
using System.Reflection;

namespace RMorais.IgniteCaptcha
{
    public static class IgniteCaptcha
    {
        private static int Width;
        private static int Height;
        public static string GenCaptcha(string path,int width,int height,out string captcha)
        {
            Width = width;
            Height = height;
            CaptchaAtribute cptAtrib = CalculateCaptchaAtributes();

            using (Image<Rgba32> img = new Image<Rgba32>(width, height))
            {


                img.Mutate(ctx => ctx
                    .Fill(Rgba32.LightGray) // white background image
                    .DrawPolygon(cptAtrib.Lines[0].Color, cptAtrib.Lines[0].LineSize, cptAtrib.Lines[0].Points)
                    .DrawPolygon(cptAtrib.Lines[1].Color, cptAtrib.Lines[1].LineSize, cptAtrib.Lines[1].Points)
                    .DrawPolygon(cptAtrib.Lines[2].Color, cptAtrib.Lines[2].LineSize, cptAtrib.Lines[2].Points)
                    .DrawPolygon(cptAtrib.Lines[3].Color, cptAtrib.Lines[3].LineSize, cptAtrib.Lines[3].Points)
                    .DrawPolygon(cptAtrib.Lines[4].Color, cptAtrib.Lines[4].LineSize, cptAtrib.Lines[4].Points)
                    .DrawText(cptAtrib.Caracteres[0].Caracter,
                            SystemFonts.CreateFont(cptAtrib.Caracteres[0].FontName, cptAtrib.Caracteres[0].FontSize, cptAtrib.Caracteres[0].Style), cptAtrib.Caracteres[0].Color, cptAtrib.Caracteres[0].Point)
                  .DrawText(cptAtrib.Caracteres[1].Caracter,
                            SystemFonts.CreateFont(cptAtrib.Caracteres[1].FontName, cptAtrib.Caracteres[1].FontSize, cptAtrib.Caracteres[1].Style), cptAtrib.Caracteres[1].Color, cptAtrib.Caracteres[1].Point)
                     .DrawText(cptAtrib.Caracteres[2].Caracter,
                            SystemFonts.CreateFont(cptAtrib.Caracteres[2].FontName, cptAtrib.Caracteres[2].FontSize, cptAtrib.Caracteres[2].Style), cptAtrib.Caracteres[2].Color, cptAtrib.Caracteres[2].Point)
                     .DrawText(cptAtrib.Caracteres[3].Caracter,
                            SystemFonts.CreateFont(cptAtrib.Caracteres[3].FontName, cptAtrib.Caracteres[3].FontSize, cptAtrib.Caracteres[3].Style), cptAtrib.Caracteres[3].Color, cptAtrib.Caracteres[3].Point)
                    .DrawText(cptAtrib.Caracteres[4].Caracter,
                            SystemFonts.CreateFont(cptAtrib.Caracteres[4].FontName, cptAtrib.Caracteres[4].FontSize, cptAtrib.Caracteres[4].Style), cptAtrib.Caracteres[4].Color, cptAtrib.Caracteres[4].Point)
                     );

              
                                                        
                string filename = String.Concat(Guid.NewGuid().ToString(),".png");
                img.Save(path + "/"+ filename);
                captcha = cptAtrib.CaptchaValue;
                return filename;
            }
        }
        private static CaptchaAtribute CalculateCaptchaAtributes() {
            int wdStep = Width / 5;
            string RefCaracter = "ABCDEFGHIJLMNPQRSTUVWXYZ0123456789abcdefghijlmnopqrstuvwxyz";
            CaptchaAtribute result= new CaptchaAtribute(new WriteLine[5],new WriteCaractere[5]);

            for (int i = 0; i<5; i++) {
                Random GenH = new Random((int)DateTime.Now.Ticks & 0x0000CCCC);
                Random GenV = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
                WriteLine cptline = new WriteLine(new PointF[5]);
                for (int j = 0; j < 5; j++) {
                    PointF p =new PointF(GenH.Next(wdStep * (j + 1)), GenV.Next(0, Height));
                    cptline.LineSize = GenH.Next(1, 8);
                    cptline.Color=GetColor(GenV.Next(0, 140));
                    cptline.Points[j] = p;
                }
                WriteCaractere cptCaracter = new WriteCaractere();
                cptCaracter.Color = GetColor(GenV.Next(0, 140));
                /// startV = wdStep * i;
                cptCaracter.FontSize = GenH.Next(40, 60);
                cptCaracter.Caracter =RefCaracter[GenH.Next(0, RefCaracter.Length - 1)].ToString();
                cptCaracter.FontName = Descriptions.Fonts.GetName(GenV.Next(0, 2));
                PointF pc = new PointF(10 + GenH.Next(wdStep * i, (wdStep * i + 1)), 5 + GenV.Next(0, Height -(cptCaracter.FontSize+10)));
                cptCaracter.Point = pc;
                cptCaracter.Style = Descriptions.Fonts.GetStyle(GenV.Next(0, 3));
                result.Caracteres[i] = cptCaracter;
                result.Lines[i] = cptline;
            }

            return result;

        }

        public static SixLabors.ImageSharp.Rgba32 GetColor(int paran)
        {
            SixLabors.ImageSharp.Rgba32 result = SixLabors.ImageSharp.Rgba32.Black;

            SixLabors.ImageSharp.Rgba32 a = SixLabors.ImageSharp.Rgba32.Black;

            var mst = from c in a.GetType().GetFields()
                      where c.FieldType == typeof(SixLabors.ImageSharp.Rgba32)
                      select c;

            var b = (SixLabors.ImageSharp.Rgba32)typeof(SixLabors.ImageSharp.Rgba32).InvokeMember(
                mst.ToArray()[paran].Name,
                BindingFlags.GetField, null, null, new object[] { });
            result = b;

            return result;
        }

     }
}

