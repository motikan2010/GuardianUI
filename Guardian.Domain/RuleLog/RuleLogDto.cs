using Guardian.Domain.Target;
using Guardian.Infrastructure.Entity;
using Guardian.Infrastructure.Entity.Specs;
using System;

namespace Guardian.Domain.RuleLog
{
    public class RuleLogDto : DtoBase, IRuleLog
    {
        public Guid? FirewallRuleId { get; set; }
        public RuleLogDto FirewallRuleLog { get; set; }
        public bool IsHitted { get; set; }
        public int ExecutionMillisecond { get; set; }
        public LogType LogType { get; set; }
        public string Description { get; set; }
        public Guid TargetId { get; set; }
        public virtual TargetDto Target { get; set; }
        public string RequestUri { get; set; }
        public RuleFor RuleFor { get; set; }
        public WafAction WafAction { get; set; }
    }
}
