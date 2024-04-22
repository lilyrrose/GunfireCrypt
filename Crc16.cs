﻿namespace GunfireCrypt;

public static class Crc16
{
    private static readonly ushort[] table =
    [
        0, 16449, 32898, 49347, 16641, 320, 49539, 33218, 33282, 49731, 640, 17089, 49923, 33602, 17281, 960, 17409,
        1088, 50307, 33986, 1280, 17729, 34178, 50627, 50691, 34370, 18049, 1728, 34562, 51011, 1920, 18369, 34818,
        51267, 2176, 18625, 51459, 35138, 18817, 2496, 2560, 19009, 35458, 51907, 19201, 2880, 52099, 35778, 52227,
        35906, 19585, 3264, 36098, 52547, 3456, 19905, 19969, 3648, 52867, 36546, 3840, 20289, 36738, 53187, 20481,
        4160, 53379, 37058, 4352, 20801, 37250, 53699, 53763, 37442, 21121, 4800, 37634, 54083, 4992, 21441, 5120,
        21569, 38018, 54467, 21761, 5440, 54659, 38338, 38402, 54851, 5760, 22209, 55043, 38722, 22401, 6080, 55299,
        38978, 22657, 6336, 39170, 55619, 6528, 22977, 23041, 6720, 55939, 39618, 6912, 23361, 39810, 56259, 39938,
        56387, 7296, 23745, 56579, 40258, 23937, 7616, 7680, 24129, 40578, 57027, 24321, 8000, 57219, 40898, 40962,
        57411, 8320, 24769, 57603, 41282, 24961, 8640, 8704, 25153, 41602, 58051, 25345, 9024, 58243, 41922, 58371,
        42050, 25729, 9408, 42242, 58691, 9600, 26049, 26113, 9792, 59011, 42690, 9984, 26433, 42882, 59331, 10240,
        26689, 43138, 59587, 26881, 10560, 59779, 43458, 43522, 59971, 10880, 27329, 60163, 43842, 27521, 11200, 27649,
        11328, 60547, 44226, 11520, 27969, 44418, 60867, 60931, 44610, 28289, 11968, 44802, 61251, 12160, 28609, 61443,
        45122, 28801, 12480, 45314, 61763, 12672, 29121, 29185, 12864, 62083, 45762, 13056, 29505, 45954, 62403, 46082,
        62531, 13440, 29889, 62723, 46402, 30081, 13760, 13824, 30273, 46722, 63171, 30465, 14144, 63363, 47042, 30721,
        14400, 63619, 47298, 14592, 31041, 47490, 63939, 64003, 47682, 31361, 15040, 47874, 64323, 15232, 31681, 15360,
        31809, 48258, 64707, 32001, 15680, 64899, 48578, 48642, 65091, 16000, 32449, 65283, 48962, 32641, 16320
    ];

    public static ushort ComputeChecksum(byte[] bytes)
    {
        ushort crc = 0;
        foreach (var b in bytes)
        {
            var index = (byte)(b ^ crc);
            crc = (ushort)(table[index] ^ (crc >> 8));
        }

        return crc;
    }
}