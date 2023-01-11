using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SystemBox.Simpls
{


    //https://tilda.cc/colors/
    public static class TColor
    {
        public static Color RandomColor()
        {
            List<List<string>> AllStrings = new List<List<string>>()
                { gBlue, gLight_blue, gMint, gGreen, gLight_green, gYellow, gPeach, gOrange, gPink, gRed, gPurple, gViolet, gDark_gray, gLight_gray, gBackground_gray_shades };
            int RAnLiss = Random.Range(0, AllStrings.Count);
            int RanItem = Random.Range(0, AllStrings[RAnLiss].Count);
            if (ColorUtility.TryParseHtmlString(AllStrings[RAnLiss][RanItem], out Color newCol))
            {
                return newCol;
            }
            return Color.white;
        }
        public static Color RandomColor(Colors_F item)
        {

            List<List<string>> AllStrings = new List<List<string>>()
                { gBlue, gLight_blue, gMint, gGreen, gLight_green, gYellow, gPeach, gOrange, gPink, gRed, gPurple, gViolet, gDark_gray, gLight_gray, gBackground_gray_shades };

            int RAnLiss = Random.Range(0, AllStrings.Count);
            if (item == Colors_F.Blue) RAnLiss = 0;
            else if (item == Colors_F.Light_blue) RAnLiss = 1;
            else if (item == Colors_F.Mint) RAnLiss = 2;
            else if (item == Colors_F.Green) RAnLiss = 3;
            else if (item == Colors_F.Light_green) RAnLiss = 4;
            else if (item == Colors_F.Yellow) RAnLiss = 5;
            else if (item == Colors_F.Peach) RAnLiss = 6;
            else if (item == Colors_F.Orange) RAnLiss = 7;
            else if (item == Colors_F.Pink) RAnLiss = 8;
            else if (item == Colors_F.Red) RAnLiss = 9;
            else if (item == Colors_F.Purple) RAnLiss = 10;
            else if (item == Colors_F.Violet) RAnLiss = 11;
            else if (item == Colors_F.Dark_gray) RAnLiss = 12;
            else if (item == Colors_F.Light_gray) RAnLiss = 13;
            else if (item == Colors_F.Background_gray_shades) RAnLiss = 14;


            int RanItem = Random.Range(0, AllStrings[RAnLiss].Count);
            if (ColorUtility.TryParseHtmlString(AllStrings[RAnLiss][RanItem], out Color newCol))
            {
                return newCol;
            }
            return Color.white;
        }
        public static Color RandomColor(List<Colors_F> items)
        {

            List<List<string>> AllStrings = new List<List<string>>()
                { gBlue, gLight_blue, gMint, gGreen, gLight_green, gYellow, gPeach, gOrange, gPink, gRed, gPurple, gViolet, gDark_gray, gLight_gray, gBackground_gray_shades };

            int RAnLiss = Random.Range(0, AllStrings.Count);
            List<int> vs = new List<int>();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == Colors_F.Blue) vs.Add(0);
                else if (items[i] == Colors_F.Light_blue) vs.Add(1);
                else if (items[i] == Colors_F.Mint) vs.Add(2);
                else if (items[i] == Colors_F.Green) vs.Add(3);
                else if (items[i] == Colors_F.Light_green) vs.Add(4);
                else if (items[i] == Colors_F.Yellow) vs.Add(5);
                else if (items[i] == Colors_F.Peach) vs.Add(6);
                else if (items[i] == Colors_F.Orange) vs.Add(7);
                else if (items[i] == Colors_F.Pink) vs.Add(8);
                else if (items[i] == Colors_F.Red) vs.Add(9);
                else if (items[i] == Colors_F.Purple) vs.Add(10);
                else if (items[i] == Colors_F.Violet) vs.Add(11);
                else if (items[i] == Colors_F.Dark_gray) vs.Add(12);
                else if (items[i] == Colors_F.Light_gray) vs.Add(13);
                else if (items[i] == Colors_F.Background_gray_shades) vs.Add(14);
            }
            RAnLiss = vs[Random.Range(0, vs.Count)];
            int RanItem = Random.Range(0, AllStrings[RAnLiss].Count);
            if (ColorUtility.TryParseHtmlString(AllStrings[RAnLiss][RanItem], out Color newCol))
            {
                return newCol;
            }
            return Color.white;
        }

        public enum Colors_F
        {
            Blue, Light_blue, Mint, Green, Light_green, Yellow, Peach, Orange, Pink, Red, Purple, Violet, Dark_gray, Light_gray, Background_gray_shades
        }

        public static Color Blue
        {
            get
            {
                if (ColorUtility.TryParseHtmlString(gBlue[0], out Color newCol))
                {
                    return newCol;
                }
                return Color.white;
            }
        }
        public static Color Light_blue
        {
            get
            {
                if (ColorUtility.TryParseHtmlString(gLight_blue[0], out Color newCol))
                {
                    return newCol;
                }
                return Color.white;
            }
        }
        public static Color Mint
        {
            get
            {
                if (ColorUtility.TryParseHtmlString(gMint[0], out Color newCol))
                {
                    return newCol;
                }
                return Color.white;
            }
        }
        public static Color Green
        {
            get
            {
                if (ColorUtility.TryParseHtmlString(gGreen[0], out Color newCol))
                {
                    return newCol;
                }
                return Color.white;
            }
        }
        public static Color Light_green
        {
            get
            {
                if (ColorUtility.TryParseHtmlString(gLight_green[0], out Color newCol))
                {
                    return newCol;
                }
                return Color.white;
            }
        }
        public static Color Yellow
        {
            get
            {
                if (ColorUtility.TryParseHtmlString(gYellow[0], out Color newCol))
                {
                    return newCol;
                }
                return Color.white;
            }
        }
        public static Color Peach
        {
            get
            {
                if (ColorUtility.TryParseHtmlString(gPeach[0], out Color newCol))
                {
                    return newCol;
                }
                return Color.white;
            }
        }
        public static Color Orange
        {
            get
            {
                if (ColorUtility.TryParseHtmlString(gOrange[0], out Color newCol))
                {
                    return newCol;
                }
                return Color.white;
            }
        }
        public static Color Pink
        {
            get
            {
                if (ColorUtility.TryParseHtmlString(gPink[0], out Color newCol))
                {
                    return newCol;
                }
                return Color.white;
            }
        }
        public static Color Red
        {
            get
            {
                if (ColorUtility.TryParseHtmlString(gRed[0], out Color newCol))
                {
                    return newCol;
                }
                return Color.white;
            }
        }
        public static Color Purple
        {
            get
            {
                if (ColorUtility.TryParseHtmlString(gPurple[0], out Color newCol))
                {
                    return newCol;
                }
                return Color.white;
            }
        }
        public static Color Violet
        {
            get
            {
                if (ColorUtility.TryParseHtmlString(gViolet[0], out Color newCol))
                {
                    return newCol;
                }
                return Color.white;
            }
        }
        public static Color Dark_gray
        {
            get
            {
                if (ColorUtility.TryParseHtmlString(gDark_gray[0], out Color newCol))
                {
                    return newCol;
                }
                return Color.white;
            }
        }
        public static Color Background_gray_shades
        {
            get
            {
                if (ColorUtility.TryParseHtmlString(gBackground_gray_shades[0], out Color newCol))
                {
                    return newCol;
                }
                return Color.white;
            }
        }

        public static List<string> gBlue = new List<string>(){ "#5199FF", "#1771F1","#0260E8", "#0351C1" ,
                                                                    "#0351C1", "#0043A4","#002D6D","#052555",
                                                                    "#01142F","#2300B0","#242240","#2E3F7F","#4A69FF"
            };

        public static List<string> gLight_blue = new List<string>(){ "#E5F0FF", "#B7D4FF","#7EB3FF", "#51EAFF" ,
                                                                    "#BDCCFF", "#7AB1FF","#64C7FF","#D7FFFE",
                                                                    "#D7E1E9","#F2F8FD","#AFCFEA","#1EC9E8"
            };

        public static List<string> gMint = new List<string>(){ "#E4FFF9", "#B5FBDD","#76FEC5", "#45D09E" ,
                                                                    "#17F1D7", "#00CF91","#48CFAF","#00848C",
                                                                    "#AEE8E4","#00DFC8","#2398AB","#1EC9E8"
            };

        public static List<string> gGreen = new List<string>(){ "#5BFF62", "#41B619","#117243", "#116315" ,
                                                                    "#4BB462", "#008736","#4D8802","#1E3C00",
                                                                    "#00DC7D","#77BD8B","#70E852","#35D073"
            };
        public static List<string> gLight_green = new List<string>(){ "#BEF761", "#CEFF9D","#C9FFBF", "#A7E541" ,
                                                                    "#CBE724", "#8CBA51","#8EAF0C","#748700"
            };
        public static List<string> gYellow = new List<string>(){ "#FFD600", "#FFFCBB","#FED876", "#FFE55E" ,
                                                                    "#FFEB7F", "#F4EDB2", "#FFF851","#F7F272",
                                                                    "#EEDC7C", "#F5E027",  "#D6C21A","#D2AA1B",
                                                                    "#FFC11E", "#FFE9A0",  "#FBFF00","#EAE114"
            };
        public static List<string> gPeach = new List<string>(){  "#FBE7B5", "#FBCEB5", "#FE9E76", "#FFE0BC" ,
                                                                    "#FF756B", "#F85C50", "#FB9F82","#FFA96B"
            };

        public static List<string> gOrange = new List<string>(){  "#FFC46B", "#FFAF50", "#FC9A40", "#FF905A" ,
                                                                    "#FFAD32", "#DF8600", "#FF7A2F","#FF6B00",
                                                                    "#FFCB8B", "#FE634E", "#FDA371","#F39629"
            };

        public static List<string> gPink = new List<string>(){  "#FFDFDC", "#E8D5D5", "#F5B2AC", "#FF9CA1" ,
                                                                    "#DCABAE", "#FEAC92", "#FF7272","#E85668",
                                                                    "#FF2970", "#DB6B88", "#BE5D77","#F59BAF",
                                                                    "#F6DDDF", "#DEC0C1", "#FF008B","#FF005C"
            };
        public static List<string> gRed = new List<string>(){  "#F6522E", "#FF6E4E", "#FF6A61", "#E20338" ,
                                                                    "#B40A1B", "#EE3D48", "#460000","#922D25",
                                                                    "#FF2970", "#DB6B88", "#BE5D77","#F59BAF",
                                                                    "#FF0000", "#BC0022", "#CE3D1D","#D8664D"
            };
        public static List<string> gPurple = new List<string>(){  "#EF2FA2", "#C23A94", "#CA1A8E", "#E47CCD" ,
                                                                    "#B10361", "#DC3790", "#FD0079","#810B44",
                                                                    "#A854A5", "#FFBEED", "#B9789F","#7C3668",
                                                                    "#380438", "#F375F3", "#F375CF","#AE3F7B"
            };

        public static List<string> gViolet = new List<string>(){  "#782FEF", "#6E36CA", "#4400B2", "#A771FE" ,
                                                                    "#2D1457", "#761CEA", "#852EBA","#3F0B81",
                                                                    "#580BE4", "#9A76B3", "#9A76B3","#940CFE"
            };

        public static List<string> gDark_gray = new List<string>(){  "#231F20", "#414042", "#58595B", "#6D6E71" ,
                                                                    "#808285", "#939598"
            };

        public static List<string> gLight_gray = new List<string>(){  "#FFFFFF", "#F1F2F2", "#E6E7E8", "#D1D3D4" ,
                                                                    "#BCBEC0"
            };
        public static List<string> gBackground_gray_shades = new List<string>(){  "#FAFAF2", "#F2F4F6", "#F5F2F0", "#F0F0F0" ,
                                                                                        "#F1F6FB", "#EDEDED", "#F7F7F2", "#EEF0ED" ,
                                                                                        "#F2F2E5", "#F0F6F4", "#D4DADE", "#FBF8F5" ,
                                                                                        "#C1BBB7", "#F1EBE5", "#EAE6E1", "#EEEDEA" ,
                                                                                        "#4A586E", "#2F3538", "#DAE4E5", "#D5D5D5" ,
                                                                                        "#1A2026", "#BBC9DD", "#2F3640", "#D5D5D5" ,
                                                                                        "#8C8C8C", "#535353", "#DCE5E7", "#404040" ,
            };
    }

}
