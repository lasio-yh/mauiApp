﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Foundation.Contracts;
using Microsoft.Maui.ApplicationModel;

namespace Foundation.Services
{
    public class UtilityService : IUtilityService
    {
        public Timer _timer;
        public delegate void PushHandler(object args);
        public PushHandler _push;

        /// <summary>
        /// 타이머를 생성합니다.
        /// </summary>
        public void CreateTimer(PushHandler callBack)
        {
            _push = callBack;
            _timer = new Timer(CallBackProc);
        }

        /// <summary>
        /// 타이머를 설정합니다.
        /// </summary>
        public void Setting(int duetime, int period)
        {
            _timer.Change(duetime, period);
        }

        private void CallBackProc(object obj)
        {
            _push(obj);
        }

        public byte[] StructureToByte(object obj)
        {
            int datasize = Marshal.SizeOf(obj);                 // 구조체에 할당된 메모리의 크기를 구한다.
            IntPtr buff = Marshal.AllocHGlobal(datasize);       // 비관리 메모리 영역에 구조체 크기만큼의 메모리를 할당한다.
            Marshal.StructureToPtr(obj, buff, false);           // 할당된 구조체 객체의 주소를 구한다.
            byte[] data = new byte[datasize];                   // 구조체가 복사될 배열
            Marshal.Copy(buff, data, 0, datasize);              // 구조체 객체를 배열에 복사
            Marshal.FreeHGlobal(buff);                          // 비관리 메모리 영역에 할당했던 메모리를 해제함
            return data;                                        // 배열을 리턴
        }

        public object ByteToStructure(byte[] data, Type type)
        {
            IntPtr buff = Marshal.AllocHGlobal(data.Length);    // 배열의 크기만큼 비관리 메모리 영역에 메모리를 할당한다.
            Marshal.Copy(data, 0, buff, data.Length);           // 배열에 저장된 데이터를 위에서 할당한 메모리 영역에 복사한다.
            object obj = Marshal.PtrToStructure(buff, type);    // 복사된 데이터를 구조체 객체로 변환한다.
            Marshal.FreeHGlobal(buff);                          // 비관리 메모리 영역에 할당했던 메모리를 해제함
            if (Marshal.SizeOf(obj) != data.Length)             // 구조체와 원래의 데이터의 크기 비교
            {
                return null;                                    // 크기가 다르면 null 리턴
            }
            return obj;                                         // 구조체 리턴
        }
    }
}
