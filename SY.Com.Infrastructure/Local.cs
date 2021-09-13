using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace SY.Com.Infrastructure
{
    public class Local
    {

    /// <summary>
    /// 最后一次获取_LastUsed的时间周期数
    /// </summary>
    private static long _lastTime;

    /// <summary>
    /// 最后一次获取的当前进程Cpu使用总计时周期数
    /// </summary>
    private static long _lastUsed;

    /// <summary>
    /// 当前进程
    /// </summary>
    private static Process _process;

    /// <summary>
    /// 获取当前进程的Cpu使用率
    /// </summary>
    public static byte CpuUsed
    {
        get
        {
            if (_process == null)
            {
                _process = Process.GetCurrentProcess();
            }
            if (_lastTime == 0)
            {
                _lastTime = _process.StartTime.Ticks;
            }
            var total = DateTime.Now.Ticks - _lastTime;
            var used = _process.TotalProcessorTime.Ticks - _lastUsed;
            _lastTime += total;
            _lastUsed += used;
            return (byte)(total == 0 ? 0 : (used * 100 / total / Environment.ProcessorCount));
        }
    }

    /// <summary>
    /// 获得当前进程的内存使用量
    /// </summary>
    public static long MemoryUsed
    {
        get { return Process.GetCurrentProcess().WorkingSet64; }
    }

    /// <summary>
    /// 获取当前应用程序目录
    /// </summary>
    public static string ApplicationDirectory
    {
        get { return AppDomain.CurrentDomain.SetupInformation.ApplicationBase; }
    }

    /// <summary>
    /// 获取当前工作目录
    /// </summary>
    public static string WorkDirectory
    {
        get { return Environment.CurrentDirectory; }
    }

    /// <summary>
    /// 结合当前应用程序目录获取指定路径的完整路径
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <returns>返回指定路径的完整路径</returns>
    public static string GetFullPathOfApplication(string filePath)
    {
        if (Path.IsPathRooted(filePath))
        {
            return Path.GetFullPath(filePath);
        }
        return Path.GetFullPath(string.Format("{0}{1}{2}", ApplicationDirectory, Path.DirectorySeparatorChar, filePath));
    }

    /// <summary>
    /// 结合当前工作目录获取指定路径的完整路径
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <returns>返回指定路径的完整路径</returns>
    public static string GetFullPathOfWork(string filePath)
    {
        if (Path.IsPathRooted(filePath))
        {
            return Path.GetFullPath(filePath);
        }
        return Path.GetFullPath(string.Format("{0}{1}{2}", WorkDirectory, Path.DirectorySeparatorChar, filePath));
    }

    /// <summary>
    /// 获取当前环境中有效的IP地址集
    /// </summary>
    public static IPAddress[] IPAddresses
    {
        get
        {
            var list = new List<IPAddress>();
            NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var netInterface in allNetworkInterfaces)
            {
                if (NetInterfaceFiltering(netInterface))
                {
                    var unicastAddresses = netInterface.GetIPProperties().UnicastAddresses;
                    foreach (var information in unicastAddresses)
                    {
                        if (information.IsDnsEligible)
                        {
                            list.Add(information.Address);
                        }
                    }
                }
            }
            return list.ToArray();
        }
    }

    /// <summary>
    /// 获取当前环境中有效的首个IPv4地址
    /// </summary>
    public static IPAddress IPv4Address
    {
        get
        {
            IPAddress[] ipAddresses = IPAddresses;
            foreach (var ipAddress in ipAddresses)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ipAddress;
                }
            }
            return null;
        }
    }

    /// <summary>
    /// 获取当前环境中有效的首个IPv6地址
    /// </summary>
    public static IPAddress IPv6Address
    {
        get
        {
            IPAddress[] ipAddresses = IPAddresses;
            foreach (var ipAddress in ipAddresses)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    return ipAddress;
                }
            }
            return null;
        }
    }

    /// <summary>
    /// 获取当前环境中域名服务器IP地址集
    /// </summary>
    public static IPAddress[] DnsAddresses
    {
        get
        {
            var list = new List<IPAddress>();
            NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var netInterface in allNetworkInterfaces)
            {
                if (NetInterfaceFiltering(netInterface))
                {
                    var unicastAddresses = netInterface.GetIPProperties().UnicastAddresses;
                    foreach (var information in unicastAddresses)
                    {
                        if (information.IsDnsEligible)
                        {
                            var dnsAddresses = netInterface.GetIPProperties().DnsAddresses;
                            foreach (var dnsAddress in dnsAddresses)
                            {
                                if (!list.Contains(dnsAddress))
                                {
                                    list.Add(dnsAddress);
                                }
                            }
                            break;
                        }
                    }
                }
            }
            return list.ToArray();
        }
    }

    /// <summary>
    /// 获取当前环境中网关服务器IP地址集
    /// </summary>
    public static IPAddress[] GatewayAddresses
    {
        get
        {
            var list = new List<IPAddress>();
            NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var netInterface in allNetworkInterfaces)
            {
                if (NetInterfaceFiltering(netInterface))
                {
                    var unicastAddresses = netInterface.GetIPProperties().UnicastAddresses;
                    foreach (var information in unicastAddresses)
                    {
                        if (information.IsDnsEligible)
                        {
                            var gatewayAddresses = netInterface.GetIPProperties().GatewayAddresses;
                            foreach (var gateInfo in gatewayAddresses)
                            {
                                if (!list.Contains(gateInfo.Address))
                                {
                                    list.Add(gateInfo.Address);
                                }
                            }
                            break;
                        }
                    }
                }
            }
            return list.ToArray();
        }
    }

    /// <summary>
    /// 网络接口过滤
    /// </summary>
    /// <param name="ni">网络接口</param>
    /// <returns>返回是否过滤的结果，true表示通过，false表示不通过</returns>
    private static bool NetInterfaceFiltering(NetworkInterface ni)
    {
        if (ni.NetworkInterfaceType == NetworkInterfaceType.Tunnel)
        {
            return false;
        }

        if (ni.NetworkInterfaceType == NetworkInterfaceType.Loopback)
        {
            return false;
        }

        if (ni.NetworkInterfaceType == NetworkInterfaceType.Unknown)
        {
            return false;
        }

        return true;
    }
}
}
