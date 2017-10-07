using MonthlyDutyTable.Roles;

namespace MonthlyDutyTable.Time
{
    public sealed class Duty<Time> where Time : TimePeriod
    {
        public bool IsGuarding { get; }
        public Time DaysTime { get; }
        public Role Role { get; }

        public Duty(bool isGuarding, Time daysTime, Role role)
        {
            IsGuarding = isGuarding;
            DaysTime = daysTime;
            Role = role;
        }

        public override string ToString()
        {
            var role = Role.AsString();
            var guarding = IsGuarding ? "guarding" : "not guarding";
            var days = DaysTime.ToString();
            return $"{days}: {role} {guarding}";
        }
    }

    public static class Duty
    {
        public static Duty<Night>[] Nights(params Duty<Night>[] nights) => nights;
        public static Duty<Shabath>[] Shabathes(params Duty<Shabath>[] shabathes) => shabathes;
    }
}
