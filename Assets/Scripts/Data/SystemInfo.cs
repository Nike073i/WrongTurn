using Microsoft.Win32;
using System;
using System.Collections.Generic;

public class SystemInfo
{
    public static Guid GetMachineGuid()
    {
        string location = @"SOFTWARE\Microsoft\Cryptography";
        string name = "MachineGuid";

        using RegistryKey localMachineX64View =
            RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
        using RegistryKey rk = localMachineX64View.OpenSubKey(location);
        if (rk == null)
            throw new KeyNotFoundException(
                string.Format("Key Not Found: {0}", location));

        Guid? machineGuid = rk.GetValue(name) as Guid?;
        if (!machineGuid.HasValue)
            throw new IndexOutOfRangeException(
                string.Format("Index Not Found: {0}", name));

        return machineGuid.Value;
    }
}
