﻿using Akka.Actor;
using TaxiShared;

namespace TaxiBackend
{
    public class CoordinateGenerator
    {
        public CoordinateGenerator(IActorRef publisher)
        {
            for (var i = 0; i < 100; i++)
            {
                var geoCoordinateSimulator = new GeoCoordinateSimulator(i);
                geoCoordinateSimulator.Start();
                geoCoordinateSimulator.PositionChanged +=
                    (sender, args) => publisher.Tell(new Publisher.Position(args.Longitude, args.Latitude, args.Id));
            }
        }
    }
}