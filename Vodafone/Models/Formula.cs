//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vodafone.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Formula
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<short> Year { get; set; }
        public byte Currency { get; set; }
        public byte Unit { get; set; }
        public System.DateTime Create { get; set; }
        public byte Period { get; set; }
        public int Market_ID { get; set; }
        public short YearFrom { get; set; }
        public byte CalendarFrom { get; set; }
        public short YearTo { get; set; }
        public byte CalendarTo { get; set; }
        public Nullable<bool> Flex { get; set; }
        public Nullable<bool> ScoreEMP { get; set; }
        public Nullable<bool> ScoreSpot { get; set; }
        public Nullable<bool> ScoreAVGMP { get; set; }
        public Nullable<bool> ScoreCostom { get; set; }
        public Nullable<decimal> PerfectScoreValue { get; set; }
        public Nullable<bool> LockUnlock { get; set; }
        public Nullable<byte> FixMinM { get; set; }
        public Nullable<byte> FixMinQ { get; set; }
        public Nullable<byte> FixMinY { get; set; }
        public Nullable<byte> TrancheLock { get; set; }
        public Nullable<byte> TrancheUnLockM { get; set; }
        public Nullable<byte> TrancheUnLockQ { get; set; }
        public Nullable<byte> TrancheUnLockY { get; set; }
        public Nullable<byte> TrancheLockFrom { get; set; }
        public Nullable<byte> TrancheLockTo { get; set; }
        public Nullable<byte> TrancheUnLockFromM { get; set; }
        public Nullable<byte> TrancheUnLockToM { get; set; }
        public Nullable<byte> TrancheUnLockFromQ { get; set; }
        public Nullable<byte> TrancheUnLockToQ { get; set; }
        public Nullable<byte> TrancheUnLockFromY { get; set; }
        public Nullable<byte> TrancheUnLockToY { get; set; }
        public Nullable<decimal> AutoLockPriceKR { get; set; }
        public Nullable<decimal> AutoLockPriceNOK { get; set; }
        public Nullable<decimal> AutoLockPriceLTEDF { get; set; }
        public Nullable<byte> CertPeriod { get; set; }
        public Nullable<byte> CertTranche { get; set; }
        public Nullable<byte> CertMin { get; set; }
        public Nullable<byte> CertMax { get; set; }
        public Nullable<byte> CertFixSession { get; set; }
        public Nullable<bool> FixMonth { get; set; }
        public Nullable<bool> FixQuarter { get; set; }
        public Nullable<bool> FixYear { get; set; }
        public Nullable<byte> FixSession { get; set; }
        public Nullable<bool> BestPrice { get; set; }
        public Nullable<System.TimeSpan> HourToFix { get; set; }
        public Nullable<System.TimeSpan> HourToFixCert { get; set; }
        public Nullable<bool> History { get; set; }
        public Nullable<bool> NoFriday { get; set; }
        public System.Guid PublicKey { get; set; }
        public Nullable<bool> TGEIndex { get; set; }
        public Nullable<System.TimeSpan> HourToTGEIndex { get; set; }
    }
}