using we_r_of_milo;

TcpServerHost server1 = new TcpServerHost(4544); // v15, v24
TcpServerHost server2 = new TcpServerHost(4600); // v48, v63
Console.WriteLine("Starting servers...");
server1.Start();
server2.Start();
bool running = true;
Console.WriteLine("[S to stop, I to view info]");
while (running)
{
    server1.Poll();
    server2.Poll();
    if (Console.KeyAvailable)
    {
        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.I:
                Console.WriteLine("-- Clients:");
                server1.PrintClients();
                Console.WriteLine("-- Files:");
                FileManager.PrintFiles();
                Console.WriteLine("--");
                break;
            case ConsoleKey.S:
                running = false;
                break;
        }
    }
    Thread.Sleep(4);
}
server1.Stop();
server2.Stop();
