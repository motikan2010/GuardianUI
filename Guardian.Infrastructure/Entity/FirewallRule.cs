using Guardian.Infrastructure.Entity.Specs;
using System;
using System.Collections.Generic;

namespace Guardian.Infrastructure.Entity
{
    public class FirewallRule : EntityBase, IFirewallRule
    {
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
        public Guid TargetId { get; set; }
        public virtual Target Target { get; set; }
        public virtual ICollection<RuleLog> RuleLogs { get; set; }
        public RuleFor RuleFor { get; set; }
        public string Title { get; set; }
        public string Expression { get; set; }
        public string SerializedExpression { get; set; }
        public bool IsActive { get; set; }
    }
}
