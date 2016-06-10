using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace VigiothCapital.QuantTrader.Packets
{
    public class HistoryPacket : Packet
    {
        public string QueueName;
        public List<HistoryRequest> Requests = new List<HistoryRequest>();
        public HistoryPacket()
            : base(PacketType.History)
        {
        }
    }
    public class HistoryRequest
    {
        public DateTime StartTimeUtc;
        public DateTime EndTimeUtc;
        public Symbol Symbol;
        public SecurityType SecurityType;
        public Resolution Resolution;
        public string Market;
    }
    public enum HistoryResultType
    {
        File,
        Status,
        Completed,
        Error
    }
    public abstract class HistoryResult
    {
        public HistoryResultType Type { get; private set; }
        protected HistoryResult(HistoryResultType type)
        {
            Type = type;
        }
    }
    public class FileHistoryResult : HistoryResult
    {
        public string Filepath;
        public byte[] File;
        public FileHistoryResult()
            : base(HistoryResultType.File)
        {
        }
        public FileHistoryResult(string filepath, byte[] file)
            : this()
        {
            Filepath = filepath;
            File = file;
        }
    }
    public class CompletedHistoryResult : HistoryResult
    {
        public CompletedHistoryResult()
            : base(HistoryResultType.Completed)
        {
        }
    }
    public class ErrorHistoryResult : HistoryResult
    {
        public string Message;
        public ErrorHistoryResult()
            : base(HistoryResultType.Error)
        {
        }
        public ErrorHistoryResult(string message)
            : this()
        {
            Message = message;
        }
    }
    public class StatusHistoryResult : HistoryResult
    {
        public int Progress;
        public StatusHistoryResult()
            : base(HistoryResultType.Status)
        {
        }
        public StatusHistoryResult(int progress)
            : this()
        {
            Progress = progress;
        }
    }
}
