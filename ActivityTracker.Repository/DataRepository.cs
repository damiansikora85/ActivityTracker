﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using ActivityTracker.Models;

namespace ActivityTracker.Repository
{
    public class DataRepository
    {
        private static readonly DataRepository s_dataRepository =
            new DataRepository();

        public ObservableCollection<LogEntry> LogEntries { get; } =
            new ObservableCollection<LogEntry>();

        public ObservableCollection<Program> Programs { get; } =
            new ObservableCollection<Program>();

        private DataRepository()
        {
            LoadPrograms();
        }

        public static DataRepository GetInstance()
        {
            return s_dataRepository;
        }

        public Program GetProgramByProcessName(string processName)
        {
            return Programs.FirstOrDefault(p => p.ProcessName.Equals(processName, StringComparison.OrdinalIgnoreCase));
        }

        // Temporarily hard-coded population, until persistent storage technique is decided
        private void LoadPrograms()
        {
            Programs.Clear();

            // Common programs (these will be added by default, for all installations)
            Programs.Add(new Program("explorer", "File Explorer"));
            Programs.Add(new Program("powershell", "PowerShell"));
            Programs.Add(new Program("firefox", "Firefox"));

            // Uncommon programs that I personally use (these would be manually added by the user)
            Programs.Add(new Program("devenv", "Visual Studio"));
            Programs.Add(new Program("PngGauntlet", "PNGGauntlet"));
        }
    }
}