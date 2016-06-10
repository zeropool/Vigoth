#region Copyright
/*
* Copyright Onix Solutions Limited [OnixS]. All rights reserved.
*
* This software owned by Onix Solutions Limited [OnixS] and is protected by copyright law
* and international copyright treaties.
*
* Access to and use of the software is governed by the terms of the applicable ONIXS Software
* Services Agreement (the Agreement) and Customer end user license agreements granting
* a non-assignable, non-transferable and non-exclusive license to use the software
* for it's own data processing purposes under the terms defined in the Agreement.
*
* Except as otherwise granted within the terms of the Agreement, copying or reproduction of any part
* of this source code or associated reference material to any other location for further reproduction
* or redistribution, and any amendments to this copyright notice, are expressly prohibited.
*
* Any reproduction or redistribution for sale or hiring of the Software not in accordance with
* the terms of the Agreement is a violation of copyright law.
*/
#endregion

using System;
using System.Collections.Generic;

using FIXForge.NET.FIX;
using FIXForge.NET.FIX.Scheduling;

namespace SessionScheduler
{
    // Demonstrates basic use of scheduling services as well as 
    // the ability to define session sequence number reset policy.
    class Sample : IDisposable
    {
        // Dumps errors from scheduler to the console.
        class ErrorReporter
        {
            private readonly Scheduler scheduler;

            public ErrorReporter(Scheduler scheduler)
            {
                (this.scheduler = scheduler).Error += OnSchedulerError;
            }

            private void OnSchedulerError(
                object scheduler, SessionErrorEventArgs args)
            {
                Console.WriteLine(
                    "Scheduler reported error for session {0}: {1}",
                    args.Session, args.Reason);
            }
        }

        // Dumps session state changes to the console.
        class SessionStateChangeDetector
        {
            private readonly Session session;

            public SessionStateChangeDetector(Session session)
            {
                (this.session = session).StateChangeEvent += OnStateChange;
            }

            private void OnStateChange(
                object session,
                StateChangeEventArgs args)
            {
                Console.WriteLine(
                    "Session {0} changed its state from {1} to {2}.",
                    session, args.PrevState, args.NewState);
            }
        }

        // Samples configuration parameters..

        const string configFile = "Scheduler.config";

        const string acceptorSideId = "Acceptor";
        const string initiatorSideId = "Initiator";

        const ProtocolVersion protocol = ProtocolVersion.FIX44;
        const bool seqNumberLogonPolicy = true;

        private Scheduler scheduler;
        private ErrorReporter errorReporter;

        private Session acceptor;
        private Session initiator;

        // Sample schedules only initiator, therefore its 
        // state will be traced to make sure scheduler works.
        private SessionStateChangeDetector initiatorStateTracer;

        public Sample()
        {
            ConstructScheduler();
            ConstructSessions();
        }

        private void ConstructSessions()
        {
            acceptor = new Session(
                acceptorSideId, initiatorSideId,
                protocol,
                seqNumberLogonPolicy);

            initiator = new Session(
                initiatorSideId, acceptorSideId,
                protocol,
                seqNumberLogonPolicy);

            initiatorStateTracer = 
                new SessionStateChangeDetector(
                initiator);
        }

        private void ConstructScheduler()
        {
            scheduler = new Scheduler(configFile);
            errorReporter = new ErrorReporter(scheduler);
        }

        ~Sample()
        {
            CleanUp();
        }

        public void Dispose()
        {
            CleanUp();
            GC.SuppressFinalize(this);
        }

        private void CleanUp()
        {
            scheduler.Dispose();

            initiator.Dispose();
            acceptor.Dispose();
        }

        // Carries the sample out.
        public void Run()
        {
            // Acceptor is being maintained manually.
            // Therefore, reset of sequence numbers 
            // must be done manually before logon.
            acceptor.ResetLocalSequenceNumbers();
           
            // Comment this call if you want to check 
            // how scheduler notifies about errors.
            acceptor.LogonAsAcceptor();

            SessionSchedule scheduleForInitiator = 
                ConstructShortTimeActivitySchedule();

            // Let's play the party...

            scheduler.Register(
                initiator,
                scheduleForInitiator,
                scheduler.ConnectionSettings["LocalInitiator"]);

            Console.WriteLine(
                "Session {0} scheduled for automatic connection.",
                initiator);

            // Since session is initially in disconnected state 
            // we can't simply wait for logout. Instead, we have 
            // to give time for scheduler to activate session. 
            // The best and simplest approach is to wait till time 
            // of logout as it's specified in constructed schedule.

            PauseUntil(
                scheduleForInitiator.LogoutTimes[
                (int)DateTime.Now.DayOfWeek]);

            // Make sure that initiator is shutdown.
            WaitUntilLogout(initiator);
            
            // Don't forget that once initiator disconnects from 
            // the acceptor, acceptor starts waiting for next logon.
            // Since we manage it manually, we have to call logout.
            
            acceptor.Logout(); 
            WaitUntilLogout(acceptor);
        }

        // Constructs schedule with short time activity in 30 seconds.
        // Also logon time is delayed for couple of seconds to demonstrate 
        // that scheduler will connect session only when logon event occurs. 
        private static SessionSchedule 
            ConstructShortTimeActivitySchedule()
        {
            const int logonDelayInSeconds = 5;
            const int sessionDurationInSeconds = 30;

            TimeSpan logonTime = 
                DateTime.Now.TimeOfDay.Add(
                new TimeSpan(0, 0, logonDelayInSeconds));

            TimeSpan logoutTime = logonTime.Add(
                new TimeSpan(0, 0, sessionDurationInSeconds));

            return new SessionSchedule(
                DayOfWeek.Sunday, 
                DayOfWeek.Saturday,
                logonTime, 
                logoutTime, 
                SessionDuration.Day,
                SequenceNumberResetPolicy.Daily);
        }

        private static void PauseUntil(TimeSpan timeOfDay)
        {
            System.Threading.Thread.Sleep(
                timeOfDay.Subtract(DateTime.Now.TimeOfDay));
        }

        private static void WaitUntilLogout(Session session)
        {
            const int oneSecondPause = 1000;

            while (session.State != SessionState.DISCONNECTED)
                System.Threading.Thread.Sleep(oneSecondPause);
        }
    }
}
