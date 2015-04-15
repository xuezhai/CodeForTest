using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class WebServerMonitor
    {
        // dictionary to storage machine's load data
        static Dictionary<string, Queue<LoadNode>> loadDict = new Dictionary<string, Queue<LoadNode>>();
        static string hours = "Hours";
        static string minutes = "Minutes";

        public void RecordLoad(string serverName, double CPU, double RAM)
        {
            string keyName = serverName + minutes;
            LoadNode minNode = new LoadNode(serverName, CPU, RAM);
            if (loadDict.ContainsKey(keyName))
            {               
                Queue<LoadNode> existedLoadQueue = loadDict[keyName];
                if (existedLoadQueue.Count == 60)
                {
                    LoadNode hourNode = AverageLoad(serverName,  existedLoadQueue);
                    RecordHourLoad(serverName, hourNode);
                    existedLoadQueue.Dequeue();
                    existedLoadQueue.Enqueue(minNode);
                }
                else 
                {
                    existedLoadQueue.Enqueue(minNode);
                }               
            }
            else
            {
               
                Queue<LoadNode> loadQueue = new Queue<LoadNode>();
                loadQueue.Enqueue(minNode);
                loadDict.Add(keyName, loadQueue);
            }
        }

        public void DisplayLoad(string serverName)
        {
            string keyNameMin = serverName + minutes;
            string keyNameHour = serverName + hours;

            if (loadDict.ContainsKey(keyNameMin))
            {
                Queue<LoadNode> minQueue = loadDict[keyNameMin];
                displayQueue(minQueue);                
            }

            if (loadDict.ContainsKey(keyNameHour))
            {
                Queue<LoadNode> hourQueue = loadDict[keyNameHour];
                displayQueue(hourQueue);
            }
        }

        private void RecordHourLoad(string serverName, LoadNode node)
        { 
            string keyName = serverName+ hours;

            if (loadDict.ContainsKey(keyName))
            {                
                Queue<LoadNode> existedLoadQueue = loadDict[keyName];
                if (existedLoadQueue.Count == 24)
                {
                    existedLoadQueue.Dequeue();
                    existedLoadQueue.Enqueue(node);
                }
                else
                {
                    existedLoadQueue.Enqueue(node);
                }               
            }
            else
            {                
                Queue<LoadNode> loadQueue = new Queue<LoadNode>();
                loadQueue.Enqueue(node);
                loadDict.Add(keyName, loadQueue);
            }
        }

        private LoadNode AverageLoad(string serverName, Queue<LoadNode> minutesQueue)
        {
            int size = minutesQueue.Count;
            double totalRAM = 0.0;
            double totalCPU = 0.0;
            while (minutesQueue.Count > 0)
            {
                LoadNode node = minutesQueue.Dequeue();
                totalCPU = totalCPU + node.CPU;
                totalRAM = totalRAM + node.RAM;               
            }

            double avgCPU = totalCPU / size;
            double avgRAM = totalRAM / size;
            return new LoadNode(serverName, avgCPU, avgRAM);            
        }

        private void displayQueue(Queue<LoadNode> Queue)
        {               
            while (Queue.Count > 0)
            {
                LoadNode node = Queue.Dequeue();
                Console.WriteLine(node.ServerName + " at " + Queue.Count + ": CPU = " + node.CPU + "; RAM = " + node.RAM);                
            }
        }
    }

    public class LoadNode {
        private string serverName;
        private double cpu;
        private double ram;
        public LoadNode(string name, double currentCPU, double currentRAM)
        {
            serverName = name;
            cpu = currentCPU;
            ram = currentRAM;
        }

        public string ServerName
        {
            get
            {
                return serverName;
            }
            set
            {
                serverName = value;
            }
        }

        public double CPU
        {
            get
            {
                return cpu;
            }
            set
            {
                cpu = value;
            }
        }

        public double RAM
        {
            get
            {
                return ram;
            }
            set
            {
                ram = value;
            }
        }
    }
}
