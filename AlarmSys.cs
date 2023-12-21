using System;

// Define a custom EventArgs class to pass additional information with the event
public class AlarmEventArgs : EventArgs
{
    public string Message { get; set; }

    public AlarmEventArgs(string message)
    {
        Message = message;
    }
}

// Define a class for the alarm system
public class AlarmSystem
{
    // Define the delegate (if using non-generic pattern).
    public delegate void AlarmEventHandler(object sender, AlarmEventArgs e);

    // Define the event using the generic pattern.
    public event AlarmEventHandler AlarmTriggered;

    // Method to simulate the alarm going off
    public void TriggerAlarm()
    {
        Console.WriteLine("Alarm is triggered!");
        OnAlarmTriggered("Danger! Intruder detected.");
    }
    
    // Method to raise the AlarmTriggered event
    protected virtual void OnAlarmTriggered(string message)
    {
        // Raise the event only if there are subscribers
        AlarmTriggered?.Invoke(this, new AlarmEventArgs(message));
    }
}

// Define a class that will respond to the alarm event
public class SecurityMonitor
{
    // Event handler method
    public void HandleAlarm(object sender, AlarmEventArgs e)
    {
        Console.WriteLine($"Security Monitor received alarm: {e.Message}");
    }
}

//class Program
//{
//    static void Main()
//    {
//        // Create instances of the alarm system and security monitor
//        AlarmSystem alarmSystem = new AlarmSystem();
//        SecurityMonitor securityMonitor = new SecurityMonitor();

//        // Subscribe the security monitor to the alarm event
//        alarmSystem.AlarmTriggered += securityMonitor.HandleAlarm;

//        // Trigger the alarm to see the event in action
//        alarmSystem.TriggerAlarm();

//        Console.ReadLine(); // Pause to see the output
//    }
//}