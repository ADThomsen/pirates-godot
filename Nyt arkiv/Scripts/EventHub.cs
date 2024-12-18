using System;
using System.Collections.Concurrent;

namespace RacingGame.Scripts;

public static class EventHub
{
    // Define a generic delegate for event handlers.
    public delegate void EventHandler<in TEventArgs>(object sender, TEventArgs e);

    // A dictionary to hold events and their corresponding event handlers.
    private static readonly ConcurrentDictionary<string, Delegate> Events = new();

    // Method to subscribe to an event.
    public static void Subscribe<TEventArgs>(string eventName, EventHandler<TEventArgs> handler)
    {
        Events.AddOrUpdate(eventName, handler, (key, existingHandler) => (EventHandler<TEventArgs>)existingHandler + handler);
    }

    // Method to publish an event.
    public static void Publish<TEventArgs>(string eventName, object sender, TEventArgs e)
    {
        if (Events.TryGetValue(eventName, out Delegate handler))
        {
            ((EventHandler<TEventArgs>)handler)?.Invoke(sender, e);
        }
    }
}