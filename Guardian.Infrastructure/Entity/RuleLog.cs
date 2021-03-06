using Guardian.Infrastructure.Entity.Specs;
using System;

namespace Guardian.Infrastructure.Entity
{
    public class RuleLog : EntityBase, IRuleLog
    {
        public Guid TargetId { get; set; }
        public virtual Target Target { get; set; }
        public bool IsHitted { get; set; }
        public int ExecutionMillisecond { get; set; }
        public LogType LogType { get; set; }
        public string Description { get; set; }
        public Guid? FirewallRuleId { get; set; }
        public virtual FirewallRule FirewallRule { get; set; }
        public string RequestUri { get; set; }
        public RuleFor RuleFor { get; set; }
        public WafAction WafAction { get; set; }
    }
}
