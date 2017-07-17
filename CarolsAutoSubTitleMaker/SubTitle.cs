﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarolsAutoSubTitleMaker
{
    class SubTitleList
    {
        private string subTitleHead = "[Script Info]\n; Script generated by Aegisub 3.2.2\n; http://www.aegisub.org/\nTitle: Default Aegisub file\nScriptType: v4.00+\nWrapStyle: 0\nScaledBorderAndShadow: yes\nYCbCr Matrix: None\n\n\n[Aegisub Project Garbage]\n\n[V4 + Styles]\nFormat: Name, Fontname, Fontsize, PrimaryColour, SecondaryColour, OutlineColour, BackColour, Bold, Italic, Underline, StrikeOut, ScaleX, ScaleY, Spacing, Angle, BorderStyle, Outline, Shadow, Alignment, MarginL, MarginR, MarginV, Encoding\nStyle: Default,Arial,20,&H00FFFFFF,&H000000FF,&H00000000,&H00000000,0,0,0,0,100,100,0,0,1,2,2,2,10,10,10,1\n\n";
        private List<SubTitle> list = new List<SubTitle>();
        public List<SubTitle> getList()
        {
            return this.list;
        }
        public void addSubTitle(SubTitle sub)
        {
            list.Add(new SubTitle(sub));
        }
        public override string ToString()
        {
            string s = "";
            s += subTitleHead;
            foreach(var item in list)
            {
                s += item.ToString() + '\n';
            }
            return s;
        }
    }
    class SubTitle
    {
        public int StartFrame { get; set; }
        public int EndFrame { get; set; }
        public string Text { get; set; }

        public SubTitle(int start,int end,string text)
        {
            this.StartFrame = start;
            this.EndFrame = end;
            this.Text = text;
        }
        public SubTitle()
        {
            StartFrame = -1;
            EndFrame = -1;
            Text = "";
        }
        public SubTitle(SubTitle title)
        {
            StartFrame = title.StartFrame;
            EndFrame = title.EndFrame;
            Text = title.Text;
        }
        public override string ToString()
        {
            float frameRate = 59.9400599400599f;

            string startTime = frameToTime(frameRate, StartFrame);
            string endTime = frameToTime(frameRate, EndFrame);

            return String.Format("Dialogue: 0,{0},{1},Default,,0,0,0,,{2}", startTime, endTime, Text);
        }
        private string frameToTime(float frameRate,int frame)
        {
            float seconds = frame / frameRate;
            int hours = (int)(seconds / 3600);
            seconds = seconds - hours * 3600;
            int minutes = (int)(seconds / 60);
            seconds = seconds - minutes * 60;

            string time = String.Format("{0}:{1}:{2}", hours, string.Format("{0:00}", minutes), string.Format("{0:00.00}", seconds));
            return time;
        }
    }
}
