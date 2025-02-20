﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using AR.Drone.Video;
using PixelFormat = System.Drawing.Imaging.PixelFormat;
using VideoPixelFormat = AR.Drone.Video.PixelFormat;

namespace A.R.Drone.Main
{
    public static class VideoHelper
    {
        static object locker = new object();
        public static PixelFormat ConvertPixelFormat(VideoPixelFormat pixelFormat)
        {
            switch (pixelFormat)
            {
                case VideoPixelFormat.Gray8:
                    return PixelFormat.Format8bppIndexed;
                case VideoPixelFormat.BGR24:
                    return PixelFormat.Format24bppRgb;
                case VideoPixelFormat.RGB24:
                    throw new NotSupportedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static Bitmap CreateBitmap(ref VideoFrame frame)
        {
            PixelFormat pixelFormat = ConvertPixelFormat(frame.PixelFormat);
            var bitmap = new Bitmap(frame.Width, frame.Height, pixelFormat);
            if (pixelFormat == PixelFormat.Format8bppIndexed)
            {
                ColorPalette palette = bitmap.Palette;
                for (int i = 0; i < palette.Entries.Length; i++)
                {
                    palette.Entries[i] = Color.FromArgb(i, i, i);
                }
                bitmap.Palette = palette;
            }

            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData data = bitmap.LockBits(rect, ImageLockMode.WriteOnly, bitmap.PixelFormat);
            Marshal.Copy(frame.Data, 0, data.Scan0, frame.Data.Length);
            bitmap.UnlockBits(data);

            return bitmap;
        }
/*
        public static void UpdateBitmap(ref Bitmap bitmap, ref VideoFrame frame)
        {

            //Console.WriteLine("{0} - {1} ", frame.Height,frame.Width);
            lock (locker)
            {
                BitmapData data = bitmap.LockBits(new Rectangle(0, 0, frame.Width, frame.Height),
                                    ImageLockMode.WriteOnly, bitmap.PixelFormat);
                Marshal.Copy(frame.Data, 0, data.Scan0, frame.Data.Length);
                bitmap.UnlockBits(data);
            }
        }*/
    }
}