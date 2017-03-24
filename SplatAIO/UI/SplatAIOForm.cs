using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using SplatAIO.Logic;
using SplatAIO.Logic.Gecko;
using SplatAIO.Logic.Memory.Addresses;
using SplatAIO.Logic.Statistics;
using SplatAIO.Logic.Weapons;
using SplatAIO.Properties;
using SplatAIO.UI.TimerHax;
using SplatAIO.UI.Weapons;

namespace SplatAIO.UI
{
    public partial class SplatAIOForm : Form
    {
        private readonly Dictionary<uint, uint[]> clothes = new Dictionary<uint, uint[]>
        {
            {0x00000001, new uint[] {0x00000000, 0x00000000, 0x00000000}},
            {0x000003e8, new uint[] {0x00000000, 0x00000000, 0x00000000}},
            {0x000003e9, new uint[] {0x00000004, 0x00000004, 0x00000004}},
            {0x000003eb, new uint[] {0x00000004, 0x00000004, 0x00000004}},
            {0x000003ec, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x000003ed, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x000003ee, new uint[] {0x00000000, 0x00000000, 0x00000000}},
            {0x000003ef, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x000003f0, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x000003f1, new uint[] {0x00000009, 0x00000009, 0x00000009}},
            {0x000003f2, new uint[] {0x00000003, 0x00000003, 0x00000003}},
            {0x000003f3, new uint[] {0x00000009, 0x00000009, 0x00000009}},
            {0x000003f4, new uint[] {0x00000009, 0x00000009, 0x00000009}},
            {0x000003f5, new uint[] {0x00000007, 0x00000007, 0x00000007}},
            {0x000003f6, new uint[] {0x00000007, 0x00000007, 0x00000007}},
            {0x000003f7, new uint[] {0x00000001, 0x00000001, 0x00000001}},
            {0x000003f8, new uint[] {0x00000001, 0x00000001, 0x00000001}},
            {0x000003f9, new uint[] {0x00000009, 0x00000009, 0x00000009}},
            {0x000003fa, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x000003fb, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x000003fc, new uint[] {0x00000003, 0x00000003, 0x00000003}},
            {0x000003fd, new uint[] {0x00000003, 0x00000003, 0x00000003}},
            {0x000003fe, new uint[] {0x00000000, 0x00000000, 0x00000000}},
            {0x000003ff, new uint[] {0x00000000, 0x00000000, 0x00000000}},
            {0x00000402, new uint[] {0x00000003, 0x00000003, 0x00000003}},
            {0x00000403, new uint[] {0x00000009, 0x00000009, 0x00000009}},
            {0x00000405, new uint[] {0x00000003, 0x00000003, 0x00000003}},
            {0x000007d0, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x000007d1, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x000007d2, new uint[] {0x00000007, 0x00000007, 0x00000007}},
            {0x000007d3, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x000007d4, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x000007d5, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x000007d6, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x000007d7, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x000007d8, new uint[] {0x00000000, 0x00000000, 0x00000000}},
            {0x000007d9, new uint[] {0x00000001, 0x00000001, 0x00000001}},
            {0x000007da, new uint[] {0x00000000, 0x00000000, 0x00000000}},
            {0x000007db, new uint[] {0x0000000B, 0x0000000B, 0x0000000B}},
            {0x000007dc, new uint[] {0x00000001, 0x00000001, 0x00000001}},
            {0x00000bb8, new uint[] {0x00000000, 0x00000000, 0x00000000}},
            {0x00000bb9, new uint[] {0x00000000, 0x00000000, 0x00000000}},
            {0x00000bba, new uint[] {0x00000000, 0x00000000, 0x00000000}},
            {0x00000bbb, new uint[] {0x00000000, 0x00000000, 0x00000000}},
            {0x00000bbc, new uint[] {0x0000000B, 0x0000000B, 0x0000000B}},
            {0x00000bbd, new uint[] {0x00000000, 0x00000000, 0x00000000}},
            {0x00000bbe, new uint[] {0x00000007, 0x00000007, 0x00000007}},
            {0x00000bbf, new uint[] {0x00000004, 0x00000004, 0x00000004}},
            {0x00000bc0, new uint[] {0x00000007, 0x00000007, 0x00000007}},
            {0x00000bc1, new uint[] {0x00000008, 0x00000008, 0x00000008}},
            {0x00000fa0, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x00000fa1, new uint[] {0x00000007, 0x00000007, 0x00000007}},
            {0x00000fa2, new uint[] {0x00000007, 0x00000007, 0x00000007}},
            {0x00000fa3, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x00000fa4, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x00000fa5, new uint[] {0x0000000B, 0x0000000B, 0x0000000B}},
            {0x00000fa6, new uint[] {0x00000004, 0x00000004, 0x00000004}},
            {0x00000fa7, new uint[] {0x00000007, 0x00000007, 0x00000007}},
            {0x00000fa8, new uint[] {0x00000007, 0x00000007, 0x00000007}},
            {0x00001388, new uint[] {0x00000001, 0x00000001, 0x00000001}},
            {0x0000138a, new uint[] {0x00000001, 0x00000001, 0x00000001}},
            {0x0000138b, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x0000138c, new uint[] {0x0000000B, 0x0000000B, 0x0000000B}},
            {0x0000138d, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x0000138e, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x0000138f, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x00001390, new uint[] {0x0000000B, 0x0000000B, 0x0000000B}},
            {0x00001391, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x00001392, new uint[] {0x00000008, 0x00000008, 0x00000008}},
            {0x00001393, new uint[] {0x00000008, 0x00000008, 0x00000008}},
            {0x00001394, new uint[] {0x00000008, 0x00000008, 0x00000008}},
            {0x00001395, new uint[] {0x00000008, 0x00000008, 0x00000008}},
            {0x00001396, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x00001397, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x00001398, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x00001770, new uint[] {0x0000000B, 0x0000000B, 0x0000000B}},
            {0x00001771, new uint[] {0x0000000B, 0x0000000B, 0x0000000B}},
            {0x00001b58, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x00001b59, new uint[] {0x00000000, 0x00000000, 0x00000000}},
            {0x00001b5a, new uint[] {0x00000000, 0x00000000, 0x00000000}},
            {0x00001b5b, new uint[] {0x00000003, 0x00000003, 0x00000003}},
            {0x00001b5c, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x00001b5d, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x00001b5e, new uint[] {0x00000000, 0x00000000, 0x00000000}},
            {0x00001f40, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x00001f41, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x00001f42, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x00001f43, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x00001f44, new uint[] {0x0000000B, 0x0000000B, 0x0000000B}},
            {0x00001f45, new uint[] {0x00000008, 0x00000008, 0x00000008}},
            {0x00001f46, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x00001f47, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x00001f48, new uint[] {0x00000003, 0x00000003, 0x00000003}},
            {0x00001f49, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x00001f4a, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x00001f4b, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x00001f4c, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x00001f4d, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x00001f4e, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x00001f4f, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x00002328, new uint[] {0x00000001, 0x00000001, 0x00000001}},
            {0x00002329, new uint[] {0x00000001, 0x00000001, 0x00000001}},
            {0x0000232a, new uint[] {0x00000003, 0x00000003, 0x00000003}},
            {0x0000232b, new uint[] {0x00000003, 0x00000003, 0x00000003}},
            {0x0000232c, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x0000232d, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x00002710, new uint[] {0x00000003, 0x00000003, 0x00000003}},
            {0x00002711, new uint[] {0x00000003, 0x00000003, 0x00000003}},
            {0x00002712, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x00000400, new uint[] {0x00000006, 0x00000005, 0x00000005}},
            {0x00000401, new uint[] {0x0000000A, 0x0000000C, 0x00000001}},
            {0x00001772, new uint[] {0x00000000, 0x00000005, 0x00000001}},
            {0x00001f50, new uint[] {0x00000004, 0x0000000C, 0x0000000B}},
            {0x000061a8, new uint[] {0x0000000B, 0x0000000A, 0x0000000C}},
            {0x000061a9, new uint[] {0x00000007, 0x00000008, 0x00000008}},
            {0x000061aa, new uint[] {0x00000009, 0x00000001, 0x0000000C}},
            {0x00000404, new uint[] {0x0000000C, 0x0000000C, 0x00000009}},
            {0x00006978, new uint[] {0x0000000B, 0x0000000C, 0x0000000A}},
            {0x0000697c, new uint[] {0x00000008, 0x00000003, 0x00000006}},
            {0x00006d60, new uint[] {0x0000000C, 0x00000003, 0x0000000C}},
            {0x00002713, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}}
        };

        private readonly Dictionary<uint, uint[]> hats = new Dictionary<uint, uint[]>
        {
            {0x00000001, new uint[] {0x00000000, 0x00000000, 0x00000000}},
            {0x000003e8, new uint[] {0x00000009, 0x00000009, 0x00000009}},
            {0x000003e9, new uint[] {0x00000001, 0x00000001, 0x00000001}},
            {0x000003ea, new uint[] {0x00000007, 0x00000007, 0x00000007}},
            {0x000003eb, new uint[] {0x00000009, 0x00000009, 0x00000009}},
            {0x000003ec, new uint[] {0x00000009, 0x00000009, 0x00000009}},
            {0x000003ed, new uint[] {0x00000009, 0x00000009, 0x00000009}},
            {0x000003ee, new uint[] {0x00000003, 0x00000003, 0x00000003}},
            {0x000003ef, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x000003f0, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x000003f1, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x000003f2, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x000003f3, new uint[] {0x00000003, 0x00000003, 0x00000003}},
            {0x000003f4, new uint[] {0x0000000B, 0x0000000B, 0x0000000B}},
            {0x000003f6, new uint[] {0x00000004, 0x00000004, 0x00000004}},
            {0x000007d0, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x000007d1, new uint[] {0x00000001, 0x00000001, 0x00000001}},
            {0x000007d2, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x000007d3, new uint[] {0x00000009, 0x00000009, 0x00000009}},
            {0x000007d4, new uint[] {0x00000008, 0x00000008, 0x00000008}},
            {0x000007d5, new uint[] {0x00000009, 0x00000009, 0x00000009}},
            {0x00000bb8, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x00000bb9, new uint[] {0x00000008, 0x00000008, 0x00000008}},
            {0x00000bba, new uint[] {0x00000008, 0x00000008, 0x00000008}},
            {0x00000bbb, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x00000bbc, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x00000bbd, new uint[] {0x00000008, 0x00000008, 0x00000008}},
            {0x00000bbe, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x00000bbf, new uint[] {0x00000004, 0x00000004, 0x00000004}},
            {0x00000bc0, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x00000bc1, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x00000bc2, new uint[] {0x00000003, 0x00000003, 0x00000003}},
            {0x00000fa0, new uint[] {0x00000008, 0x00000008, 0x00000008}},
            {0x00000fa1, new uint[] {0x00000003, 0x00000003, 0x00000003}},
            {0x00000fa2, new uint[] {0x00000001, 0x00000001, 0x00000001}},
            {0x00000fa3, new uint[] {0x00000003, 0x00000003, 0x00000003}},
            {0x00000fa4, new uint[] {0x00000001, 0x00000001, 0x00000001}},
            {0x00000fa5, new uint[] {0x00000009, 0x00000009, 0x00000009}},
            {0x00000fa6, new uint[] {0x00000009, 0x00000009, 0x00000009}},
            {0x00000fa7, new uint[] {0x00000008, 0x00000008, 0x00000008}},
            {0x00001388, new uint[] {0x00000008, 0x00000008, 0x00000008}},
            {0x00001389, new uint[] {0x00000008, 0x00000008, 0x00000008}},
            {0x0000138a, new uint[] {0x00000008, 0x00000008, 0x00000008}},
            {0x00001770, new uint[] {0x0000000B, 0x0000000B, 0x0000000B}},
            {0x00001771, new uint[] {0x00000003, 0x00000003, 0x00000003}},
            {0x00001772, new uint[] {0x00000004, 0x00000004, 0x00000004}},
            {0x00001b58, new uint[] {0x00000009, 0x00000009, 0x00000009}},
            {0x00001b5a, new uint[] {0x00000008, 0x00000008, 0x00000008}},
            {0x00001b5b, new uint[] {0x00000008, 0x00000008, 0x00000008}},
            {0x00001b5c, new uint[] {0x00000009, 0x00000009, 0x00000009}},
            {0x00001b5d, new uint[] {0x00000009, 0x00000009, 0x00000009}},
            {0x00001f40, new uint[] {0x00000008, 0x00000008, 0x00000008}},
            {0x00001f41, new uint[] {0x00000008, 0x00000008, 0x00000008}},
            {0x00001f42, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x00001f43, new uint[] {0x00000008, 0x00000008, 0x00000008}},
            {0x00002329, new uint[] {0x0000000B, 0x0000000B, 0x0000000B}},
            {0x0000232a, new uint[] {0x0000000B, 0x0000000B, 0x0000000B}},
            {0x0000232b, new uint[] {0x00000004, 0x00000004, 0x00000004}},
            {0x0000232c, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x0000232d, new uint[] {0x00000004, 0x00000004, 0x00000004}},
            {0x000003f5, new uint[] {0x00000005, 0x00000006, 0x0000000C}},
            {0x0000232e, new uint[] {0x0000000A, 0x0000000C, 0x00000003}},
            {0x000061a8, new uint[] {0x00000006, 0x00000004, 0x00000005}},
            {0x000061a9, new uint[] {0x00000000, 0x00000001, 0x00000005}},
            {0x000061aa, new uint[] {0x00000001, 0x00000001, 0x0000000B}},
            {0x00006978, new uint[] {0x00000002, 0x00000005, 0x00000006}},
            {0x0000697c, new uint[] {0x00000007, 0x00000007, 0x00000008}},
            {0x00006d60, new uint[] {0x0000000C, 0x0000000C, 0x00000003}},
            {0x000003f7, new uint[] {0x00000000, 0x00000001, 0x00000005}},
            {0x000003f8, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}}
        };

        private readonly Dictionary<uint, uint[]> shoes = new Dictionary<uint, uint[]>
        {
            {0x00000001, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x000003e8, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x000003e9, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x000003ea, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x000003eb, new uint[] {0x0000000B, 0x0000000B, 0x0000000B}},
            {0x000003ec, new uint[] {0x0000000A, 0x0000000A, 0x0000000A}},
            {0x000003ed, new uint[] {0x0000000B, 0x0000000B, 0x0000000B}},
            {0x000003ee, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x000003ef, new uint[] {0x0000000B, 0x0000000B, 0x0000000B}},
            {0x000003f0, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x000003f1, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x000003f2, new uint[] {0x00000007, 0x00000007, 0x00000007}},
            {0x000003f3, new uint[] {0x00000007, 0x00000007, 0x00000007}},
            {0x000007d0, new uint[] {0x0000000B, 0x0000000B, 0x0000000B}},
            {0x000007d1, new uint[] {0x0000000B, 0x0000000B, 0x0000000B}},
            {0x000007d2, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x000007d3, new uint[] {0x0000000B, 0x0000000B, 0x0000000B}},
            {0x000007d4, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x000007d5, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x000007d6, new uint[] {0x0000000B, 0x0000000B, 0x0000000B}},
            {0x000007d8, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x000007d9, new uint[] {0x00000002, 0x00000002, 0x00000002}},
            {0x00000bb8, new uint[] {0x00000004, 0x00000004, 0x00000004}},
            {0x00000bb9, new uint[] {0x00000007, 0x00000007, 0x00000007}},
            {0x00000bba, new uint[] {0x00000004, 0x00000004, 0x00000004}},
            {0x00000bbb, new uint[] {0x00000007, 0x00000007, 0x00000007}},
            {0x00000bbc, new uint[] {0x00000004, 0x00000004, 0x00000004}},
            {0x00000bbd, new uint[] {0x00000004, 0x00000004, 0x00000004}},
            {0x00000bbe, new uint[] {0x00000004, 0x00000004, 0x00000004}},
            {0x00000bbf, new uint[] {0x00000004, 0x00000004, 0x00000004}},
            {0x00000bc0, new uint[] {0x00000007, 0x00000007, 0x00000007}},
            {0x00000bc1, new uint[] {0x00000004, 0x00000004, 0x00000004}},
            {0x00000fa0, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x00000fa1, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x00000fa2, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x00000fa3, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x00001388, new uint[] {0x00000001, 0x00000001, 0x00000001}},
            {0x00001389, new uint[] {0x00000001, 0x00000001, 0x00000001}},
            {0x0000138a, new uint[] {0x00000001, 0x00000001, 0x00000001}},
            {0x00001770, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x00001771, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x00001772, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x00001773, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x00001774, new uint[] {0x00000001, 0x00000001, 0x00000001}},
            {0x00001775, new uint[] {0x00000001, 0x00000001, 0x00000001}},
            {0x00001776, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x00001777, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x00001778, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x00001779, new uint[] {0x00000001, 0x00000001, 0x00000001}},
            {0x0000177a, new uint[] {0x00000004, 0x00000004, 0x00000004}},
            {0x0000177b, new uint[] {0x00000004, 0x00000004, 0x00000004}},
            {0x00001b58, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x00001b59, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x00001b5a, new uint[] {0x00000006, 0x00000006, 0x00000006}},
            {0x00001f40, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x00001f41, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x00001f42, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x00001f43, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x00001f44, new uint[] {0x00000005, 0x00000005, 0x00000005}},
            {0x00000fa6, new uint[] {0x00000000, 0x00000001, 0x00000007}},
            {0x000007d7, new uint[] {0x0000000A, 0x00000008, 0x00000007}},
            {0x000061a8, new uint[] {0x0000000B, 0x0000000C, 0x0000000C}},
            {0x000061a9, new uint[] {0x00000007, 0x00000004, 0x00000002}},
            {0x000061aa, new uint[] {0x0000000C, 0x00000007, 0x00000009}},
            {0x00006978, new uint[] {0x00000002, 0x00000004, 0x00000009}},
            {0x0000697c, new uint[] {0x00000005, 0x00000003, 0x00000006}},
            {0x00006d60, new uint[] {0x0000000C, 0x00000009, 0x00000007}}
        };

        public SplatAIOForm()
        {
            InitializeComponent();
        }

        //general vars

        public int Rank { get; set; }
        public int Okane { get; set; }
        public int Ude { get; set; }
        public int Mae { get; set; }
        public int Sazae { get; set; }
        public int Gender { get; set; }
        public int Eyes { get; set; }
        public int Skin { get; set; }
        public uint Figure { get; set; }
        public uint Offset { get; set; }
        public TCPGecko Gecko { get; set; }
        public bool SendStats { get; set; }
        public bool AutoRefresh { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            var checker = new Checker();
            if (checker.getdata() == 0 && checker.ver > GetCurrentVersion())
                checker.ShowDialog();

            Configuration.Load();
            ipBox.Text = Configuration.CurrentConfig.LastIp;

            Text += " (" + Assembly.GetExecutingAssembly().GetName().Version + ")";

            if (Configuration.CurrentConfig.AllowStatistics)
                SendStats = StatisticTransmitter.WorkingConnection();
            else
                SendStats = false;
        }

        private void connectBox_Click(object sender, EventArgs e)
        {
            Gecko = new TCPGecko(ipBox.Text);

            try
            {
                Gecko.Connect();
            }
            catch (ETCPGeckoException)
            {
                MessageBox.Show(Strings.CONNECTION_FAILED_TEXT);
            }
            catch (SocketException)
            {
                MessageBox.Show(Strings.INVALID_IP_TEXT);
            }

            //offset difference checker
            var JRAddr = Gecko.peek(0x106E975C) + 0x92D8;
            if (Gecko.peek(JRAddr) == 0x000003F2)
            {
                Offset = JRAddr - 0x12CDADA0;
            }
            else
            {
                MessageBox.Show(Strings.FIND_DIFF_FAILED_TEXT);

                Gecko.Disconnect();
                return;
            }

            // do a version check using "ToHu" of "ToHuman"
            if (Gecko.peek((uint) Octohax.Player00 + 0x50) != 0x546F4875)
            {
                MessageBox.Show(Strings.VERSION_CHECK_FAILED_TEXT);

                Gecko.Disconnect();
                return;
            }

            Configuration.CurrentConfig.LastIp = ipBox.Text;
            Configuration.Save();

            connectBox.Enabled = false;
            disconnectBox.Enabled = true;

            load();
        }

        public void release()
        {
            rankBox.Enabled = true;
            ipBox.Enabled = false;
            kaneBox.Enabled = true;
            sazaeBox.Enabled = true;
            udeBox.Enabled = true;
            maeBox.Enabled = true;
            progressFlagsBox.Enabled = true;
            genderBox.Enabled = true;
            eyeBox.Enabled = true;
            skinBox.Enabled = true;
            amiiboBox.Enabled = true;
            ikaBox.Enabled = true;
            takoBox.Enabled = true;
            aoriBox.Enabled = true;
            hotaruBox.Enabled = true;
            swapBox.Enabled = true;
            normalBox.Enabled = true;
            gameButton.Enabled = true;
            bukiButton.Enabled = true;
            gearButton.Enabled = true;
            refreshButton.Enabled = true;
            OKButton.Enabled = true;
            menuStrip.Enabled = true;
            checkBox1.Enabled = true;
            autoRefreshTimer.Enabled = true;
        }

        public void hold()
        {
            rankBox.Enabled = false;
            ipBox.Enabled = true;
            kaneBox.Enabled = false;
            sazaeBox.Enabled = false;
            udeBox.Enabled = false;
            maeBox.Enabled = false;
            progressFlagsBox.Enabled = false;
            genderBox.Enabled = false;
            eyeBox.Enabled = false;
            skinBox.Enabled = false;
            amiiboBox.Enabled = false;
            ikaBox.Enabled = false;
            aoriBox.Enabled = false;
            hotaruBox.Enabled = false;
            takoBox.Enabled = false;
            swapBox.Enabled = false;
            normalBox.Enabled = false;
            gameButton.Enabled = false;
            bukiButton.Enabled = false;
            gearButton.Enabled = false;
            refreshButton.Enabled = false;
            OKButton.Enabled = false;
            menuStrip.Enabled = false;
            checkBox1.Enabled = false;
            autoRefreshTimer.Enabled = false;
        }

        public void load()
        {
            hold();

            Rank = Convert.ToInt32(Gecko.peek((uint) Player.Rank + Offset)) + 1;
            Okane = Convert.ToInt32(Gecko.peek((uint) Player.Okane + Offset));
            Ude = Convert.ToInt32(Gecko.peek((uint) Player.Ude + Offset));
            Mae = Convert.ToInt32(Gecko.peek((uint) Player.Mae + Offset));
            Sazae = Convert.ToInt32(Gecko.peek((uint) Player.Sazae + Offset));
            Gender = Convert.ToInt32(Gecko.peek((uint) Player.Gender + Offset));
            Eyes = Convert.ToInt32(Gecko.peek((uint) Player.Eyes + Offset));
            Skin = Convert.ToInt32(Gecko.peek((uint) Player.Skin + Offset));
            Figure = Gecko.peek((uint) Player.Amiibo + Offset);

            try
            {
                rankBox.Value = Rank;
            }
            catch (ArgumentOutOfRangeException)
            {
                var rankDisplay = fixStuff(Strings.BAD_RANK_1, Rank, Strings.BAD_RANK_2, 0x12CDC1A8, 49, 50, 1);
                rankBox.Value = rankDisplay;
            }

            try
            {
                kaneBox.Value = Okane;
            }
            catch (ArgumentOutOfRangeException)
            {
                var OkaneDisplay = fixStuff(Strings.BAD_OKANE_1, Okane, Strings.BAD_OKANE_2, 0x12CDC1A0, 9999999,
                    9999999, 0);
                kaneBox.Value = OkaneDisplay;
            }

            try
            {
                maeBox.Value = Mae;
            }
            catch (ArgumentOutOfRangeException)
            {
                var maeDisplay = fixStuff(Strings.BAD_MAE_1, Mae, Strings.BAD_MAE_2, 0x12CDC1B0, 99, 99, 0);
                maeBox.Value = maeDisplay;
            }

            try
            {
                sazaeBox.Value = Sazae;
            }
            catch (ArgumentOutOfRangeException)
            {
                var sazaeDisplay = fixStuff(Strings.BAD_SAZAE_1, Sazae, Strings.BAD_SAZAE_2, 0x12CDC1B4, 999, 999, 0);
                sazaeBox.Value = sazaeDisplay;
            }

            try
            {
                udeBox.SelectedIndex = Ude;
            }
            catch (ArgumentOutOfRangeException)
            {
                var udeDisplay = fixStuff(Strings.BAD_UDE_1, Ude, Strings.BAD_UDE_2, 0x12CDC1AC, 10, 10, 0);
                udeBox.SelectedIndex = udeDisplay;
            }

            try
            {
                genderBox.SelectedIndex = Gender;
            }
            catch (ArgumentOutOfRangeException)
            {
                genderBox.SelectedIndex = 0;
                Gecko.poke32((uint) Player.Gender, 0x00000000);
            }

            if (Figure == 0xFFFFFFFF)
                amiiboBox.SelectedIndex = 0;
            else
                amiiboBox.SelectedIndex = Convert.ToInt32(Figure + 1);

            eyeBox.SelectedIndex = Eyes;
            skinBox.SelectedIndex = Skin;
            release();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            load();
        }

        private void disconnectBox_Click(object sender, EventArgs e)
        {
            disconnectBox.Enabled = false;
            hold();
            Gecko.Disconnect();
            connectBox.Enabled = true;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            hold();

            if (SendStats)
            {
                if (kaneBox.Value != Okane)
                    StatisticTransmitter.WriteToSlot(0, Math.Abs(kaneBox.Value - Okane));
                if (rankBox.Value != Rank)
                    StatisticTransmitter.WriteToSlot(3, Math.Abs(rankBox.Value - Rank));
                if (sazaeBox.Value != Sazae)
                    StatisticTransmitter.WriteToSlot(1, Math.Abs(sazaeBox.Value - Sazae));
                if (eyeBox.SelectedIndex != Eyes)
                    StatisticTransmitter.WriteToSlot(5, 1);
                if (genderBox.SelectedIndex != Gender)
                    StatisticTransmitter.WriteToSlot(4, 1);
                if (skinBox.SelectedIndex != Skin)
                    StatisticTransmitter.WriteToSlot(6, 1);
                if (udeBox.SelectedIndex != Ude || maeBox.Value != Mae)
                    StatisticTransmitter.WriteToSlot(2, 1);
            }

            pokeRank((uint) Player.Rank + Offset); // rank
            Gecko.poke32((uint) Player.Okane + Offset, Convert.ToUInt32(kaneBox.Value)); // Okane
            Gecko.poke32((uint) Player.Ude + Offset, Convert.ToUInt32(udeBox.SelectedIndex)); // ude
            Gecko.poke32((uint) Player.Mae + Offset, Convert.ToUInt32(maeBox.Value)); // mae
            Gecko.poke32((uint) Player.Sazae + Offset, Convert.ToUInt32(sazaeBox.Value)); // sazae
            Gecko.poke32((uint) Player.Gender + Offset, Convert.ToUInt32(genderBox.SelectedIndex)); // gender
            Gecko.poke32((uint) Player.Eyes + Offset, Convert.ToUInt32(eyeBox.SelectedIndex)); // eyes
            Gecko.poke32((uint) Player.Skin + Offset, Convert.ToUInt32(skinBox.SelectedIndex)); // skin
            pokeAmiibo((uint) Player.Amiibo + Offset); // amiibo

            release();
        }

        public int fixStuff(string str1, int invalid, string str2, uint fixAddress, int newPokeVal, int newVal,
            int noVal)
        {
            var fix = MessageBox.Show(str1 + invalid + str2, Strings.INVALID, MessageBoxButtons.YesNo);
            if (fix == DialogResult.Yes)
            {
                Gecko.poke32(fixAddress + Offset, Convert.ToUInt32(newPokeVal));
                return newVal;
            }
            return noVal;
        }

        public void pokeRank(uint address)
        {
            var rank = Convert.ToUInt32(rankBox.Value);
            Gecko.poke32(address, rank - 1); // rank
            Gecko.poke32(address - 0x4, 0x00000000); // experience to 0

            // set progression bits appropriately
            var progression = Gecko.peek(ProgressBitsForm.progressBitsAddress + Offset);
            ProgressBitsForm.SetFlag(ref progression, 0x100000, rank >= 20);
                // rank cap flag, remove if rank < 20, set if rank >= 20
            ProgressBitsForm.SetFlag(ref progression, 0x800, rank >= 10);
                // gachi unlocked flag, remove if rank < 10, set if rank >= 10
            Gecko.poke32(ProgressBitsForm.progressBitsAddress, progression);
        }

        public void pokeAmiibo(uint address)
        {
            if (amiiboBox.SelectedIndex == 0) // none / nashi
            {
                Gecko.poke32(address, 0xFFFFFFFF);
            }
            else
            {
                Gecko.poke32(address, Convert.ToUInt32(amiiboBox.SelectedIndex - 1));
                if (SendStats)
                    StatisticTransmitter.WriteToSlot(7, 1);
            }
        }

        public void octohax(bool octopus)
        {
            uint tnkRvlOne = 0x52766C30; // "Rvl0"
            uint tnkRvlTwo = 0x30000000; // "0"

            // Tnk_Simple 1
            Gecko.poke32((uint) Octohax.TnkSimpleOne + 0x4, tnkRvlOne);
            Gecko.poke32((uint) Octohax.TnkSimpleOne + 0x8, tnkRvlTwo);

            // Tnk_Simple 2
            Gecko.poke32((uint) Octohax.TnkSimpleTwo + 0x4, tnkRvlOne);
            Gecko.poke32((uint) Octohax.TnkSimpleTwo + 0x8, tnkRvlTwo);

            // Player00
            Gecko.poke32((uint) Octohax.Player00, 0x52697661);
            Gecko.poke32((uint) Octohax.Player00 + 0x4, 0x6C303000);

            // Player00_Hlf
            Gecko.poke32((uint) Octohax.Player00Hlf, 0x52697661);
            Gecko.poke32((uint) Octohax.Player00Hlf + 0x4, 0x6C30305F);
            Gecko.poke32((uint) Octohax.Player00Hlf + 0x8, 0x486C6600);

            // Rival_Squid
            if (octopus)
            {
                Gecko.poke32((uint) Octohax.RivalSquid, 0x52697661);
                Gecko.poke32((uint) Octohax.RivalSquid + 0x4, 0x6C5F5371);
                Gecko.poke32((uint) Octohax.RivalSquid + 0x8, 0x75696400);
            }
            else
            {
                Gecko.poke32((uint) Octohax.RivalSquid, 0x506C6179);
                Gecko.poke32((uint) Octohax.RivalSquid + 0x4, 0x65725F53);
                Gecko.poke32((uint) Octohax.RivalSquid + 0x8, 0x71756964);
            }

            // Tnk_Simple 3
            Gecko.poke32((uint) Octohax.TnkSimpleThree + 0x4, tnkRvlOne);
            Gecko.poke32((uint) Octohax.TnkSimpleThree + 0x8, tnkRvlTwo);

            // Tnk_Simple 4
            Gecko.poke32((uint) Octohax.TnkSimpleFour + 0x4, tnkRvlOne);
            Gecko.poke32((uint) Octohax.TnkSimpleFour + 0x8, tnkRvlTwo);

            // Tnk_Simple 5
            Gecko.poke32((uint) Octohax.TnkSimpleFive + 0x4, tnkRvlOne);
            Gecko.poke32((uint) Octohax.TnkSimpleFive + 0x8, tnkRvlTwo);

            if (SendStats)
                StatisticTransmitter.WriteToSlot(9, 1);
        }

        public void sisterhax(string mode)
        {
            switch (mode)
            {
                case "aori":
                    Gecko.poke32((uint) Sisterhax.Aori, 0x4E70635F);
                    Gecko.poke32((uint) Sisterhax.Aori + 4, 0x49646F6C);
                    Gecko.poke32((uint) Sisterhax.Aori + 8, 0x41000000);

                    Gecko.poke32((uint) Sisterhax.Hotaru, 0x4E70635F);
                    Gecko.poke32((uint) Sisterhax.Hotaru + 4, 0x49646F6C);
                    Gecko.poke32((uint) Sisterhax.Hotaru + 8, 0x41000000);
                    break;

                case "hotaru":
                    Gecko.poke32((uint) Sisterhax.Aori, 0x4E70635F);
                    Gecko.poke32((uint) Sisterhax.Aori + 4, 0x49646F6C);
                    Gecko.poke32((uint) Sisterhax.Aori + 8, 0x42000000);

                    Gecko.poke32((uint) Sisterhax.Hotaru, 0x4E70635F);
                    Gecko.poke32((uint) Sisterhax.Hotaru + 4, 0x49646F6C);
                    Gecko.poke32((uint) Sisterhax.Hotaru + 8, 0x42000000);
                    break;

                case "swap":
                    Gecko.poke32((uint) Sisterhax.Aori, 0x4E70635F);
                    Gecko.poke32((uint) Sisterhax.Aori + 4, 0x49646F6C);
                    Gecko.poke32((uint) Sisterhax.Aori + 8, 0x42000000);

                    Gecko.poke32((uint) Sisterhax.Hotaru, 0x4E70635F);
                    Gecko.poke32((uint) Sisterhax.Hotaru + 4, 0x49646F6C);
                    Gecko.poke32((uint) Sisterhax.Hotaru + 8, 0x41000000);
                    break;

                case "normal":
                    Gecko.poke32((uint) Sisterhax.Aori, 0x4E70635F);
                    Gecko.poke32((uint) Sisterhax.Aori + 4, 0x49646F6C);
                    Gecko.poke32((uint) Sisterhax.Aori + 8, 0x41000000);

                    Gecko.poke32((uint) Sisterhax.Hotaru, 0x4E70635F);
                    Gecko.poke32((uint) Sisterhax.Hotaru + 4, 0x49646F6C);
                    Gecko.poke32((uint) Sisterhax.Hotaru + 8, 0x42000000);
                    break;
            }

            if (SendStats)
                StatisticTransmitter.WriteToSlot(8, 1);
        }

        private void progressFlagsBox_Click(object sender, EventArgs e)
        {
            var progressBitsForm = new ProgressBitsForm();
            progressBitsForm.ShowDialog(this);
        }

        private void ikaBox_Click(object sender, EventArgs e)
        {
            octohax(false);
        }

        private void takoBox_Click(object sender, EventArgs e)
        {
            octohax(true);
        }

        private void aoriBox_Click(object sender, EventArgs e)
        {
            sisterhax("aori");
        }

        private void hotaruBox_Click(object sender, EventArgs e)
        {
            sisterhax("hotaru");
        }

        private void swapBox_Click(object sender, EventArgs e)
        {
            sisterhax("swap");
        }

        private void normalBox_Click(object sender, EventArgs e)
        {
            sisterhax("normal");
        }

        private void gameButton_Click(object sender, EventArgs e)
        {
            Gecko.poke32((uint) Player.Minigames + Offset, 0x000F0000);
        }

        private void bukiButton_Click(object sender, EventArgs e)
        {
            WeaponsForm.PokeWeapons(WeaponDatabase.Weapons, Gecko, Offset);
        }

        private void PokeGear(uint baseAddress, Dictionary<uint, uint[]> gear)
        {
            // Sort the Dictionary's keys so that starter gear will appear first
            var sortedKeys = gear.Keys.ToList();
            sortedKeys.Sort();

            foreach (var objectId in sortedKeys)
            {
                var abilities = gear[objectId];

                // Poke the memory addresses
                Gecko.poke(baseAddress, objectId); // objectId
                Gecko.poke(baseAddress + 0x00000004, 0x00000004); // level
                Gecko.poke(baseAddress + 0x00000008, 0x00000004); // slots
                Gecko.poke(baseAddress + 0x0000000C, abilities[0]); // slot 1
                Gecko.poke(baseAddress + 0x00000010, abilities[1]); // slot 2
                Gecko.poke(baseAddress + 0x00000014, abilities[2]); // slot 3
                Gecko.poke(baseAddress + 0x00000024, 0x00000024); // date
                Gecko.poke(baseAddress + 0x00000028, 0x00010000); // new flag

                // Move to next gear slot in the inventory
                baseAddress += 0x00000030;

                // debug
                // Console.WriteLine("poked (objectId = " + objectId + ", new baseAddress = " + baseAddress + ")");
            }

            if (SendStats)
                StatisticTransmitter.WriteToSlot(10, 1);
        }

        private void gearButton_Click_1(object sender, EventArgs e)
        {
            PokeGear((uint) Gear.Hats + Offset, hats);
            PokeGear((uint) Gear.Clothes + Offset, clothes);
            PokeGear((uint) Gear.Shoes + Offset, shoes);
        }

        private void singlePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var singlePlayerForm = new SinglePlayerForm();
            singlePlayerForm.ShowDialog(this);
        }

        private void timerHaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var timerHaxForm = new TimerHaxForm(Gecko);
            timerHaxForm.ShowDialog(this);
        }

        private void weaponsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var weaponsForm = new WeaponsForm(Gecko, Offset);
            weaponsForm.ShowDialog(this);
        }

        public static uint[] DumpSaveSlots(TCPGecko gecko, uint diff, uint start, uint size)
        {
            using (var memoryStream = new MemoryStream())
            {
                // dump all save slots
                gecko.Dump(start + diff, start + diff + size, memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                // convert to a uint array
                var saveSlots = new uint[size / 4];
                for (var i = 0; i < saveSlots.Length; i++)
                {
                    var buffer = new byte[4];
                    memoryStream.Read(buffer, 0, 4);
                    saveSlots[i] = ByteSwap.Swap(BitConverter.ToUInt32(buffer, 0));
                }

                return saveSlots;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) //autorefresh checkbox
        {
            if (checkBox1.Checked)
            {
                AutoRefresh = true;
                autoRefreshTimer.Enabled = true;
            }
            else
            {
                AutoRefresh = false;
                autoRefreshTimer.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) //refresh on interval
        {
            if (AutoRefresh)
                load();
        }

        public static int GetCurrentVersion()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            var builder = new StringBuilder(version.Length);

            for (var i = 0; i < version.Length; i++)
                if (!version[i].Equals('.'))
                    builder.Append(version[i]);

            return Convert.ToInt32(builder.ToString());
        }
    }
}