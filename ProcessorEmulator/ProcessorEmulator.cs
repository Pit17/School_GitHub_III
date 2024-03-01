using System;

namespace ProcessorEmulator
    {
        internal class Program
        {
            static ushort[] regs = new ushort[8];
            static ushort PC = 0;
            static ushort[] RAM = new ushort[32768];
            static Stack<ushort> stack = new Stack<ushort>();
            static ushort maxValue = 32768;
            static ushort bound = 32776;

            static void ResetMachine()
            {
                PC = 0;
                stack.Clear();
                for (int i = 0; i < regs.Length; ++i)
                    regs[i] = 0;

                for (int i = 0; i < RAM.Length; ++i)
                    RAM[i] = 0;
            }

            static ushort FetchByte()
            {
                return RAM[PC++];
            }
        static void WriteTextToFile(ushort instr_code, ushort instr_addr)
        {


            // Apre il file specificato per la scrittura
            using (StreamWriter writer = new StreamWriter(@"C:\Users\pietro.malzone\Desktop\ProcessorEmulator\JMP.txt",true))
            {
                // Scrive il testo nel file se viene effettuato un jump
                if (instr_code == 8 || instr_code == 6 || instr_code == 7)
                {
                    writer.WriteLine($"Instruzione {instr_code} all'indirizzo {instr_addr}");
                    
                    

                }
            }

        }

        static void RunMachine()
            {
                while (true)
                {
                    // Instruction Fetch
                    ushort instr_addr = PC;
                    ushort instr_code = FetchByte();
                    ushort op1, op2, op3;
                    WriteTextToFile(instr_code, instr_addr);
                    // Instruction Decode + Execute
                    switch (instr_code)
                    {
                        case 0: // halt
                            throw new Exception($"Istruzione di halt all'indirizzo {instr_addr}");
                            break;

                        case 1: // set op1, op2
                            op1 = FetchByte();
                            op2 = FetchByte();

                            if (!(op1 >= maxValue && op1 < bound))
                                throw new Exception($"Valore non valido per istruzione set all'indirizzo {instr_addr}, op1 deve essere un registro");
                            if (op2 >= bound)
                                throw new Exception($"Valore non valido per istruzione set all'indirizzo {instr_addr}, op2 out of bound");

                            if (op2 >= maxValue) op2 = regs[op2 % maxValue];

                            regs[op1 % maxValue] = op2;

                            break;

                        case 2: // push op1
                            op1 = FetchByte();

                            if (op1 >= bound)
                                throw new Exception($"Valore non valido per istruzione push all'indirizzo {instr_addr}, op1 out of bound");

                            if (op1 >= maxValue) op1 = regs[op1 % maxValue];

                            stack.Push(op1);

                            break;

                        case 3: // pop
                            op1 = FetchByte();

                            if (!(op1 >= maxValue && op1 < bound))
                                throw new Exception($"Valore non valido per istruzione pop all'indirizzo {instr_addr}, op1 deve essere un registro");

                            regs[op1 % maxValue] = stack.Pop();

                            break;

                        case 4: // eq op1, op2, op3
                            op1 = FetchByte();
                            op2 = FetchByte();
                            op3 = FetchByte();

                            if (!(op1 >= maxValue && op1 < bound))
                                throw new Exception($"Valore non valido per istruzione eq all'indirizzo {instr_addr}, op1 deve essere un registro");
                            if (op2 >= bound)
                                throw new Exception($"Valore non valido per istruzione eq all'indirizzo {instr_addr}, op2 out of bound");
                            if (op3 >= bound)
                                throw new Exception($"Valore non valido per istruzione eq all'indirizzo {instr_addr}, op3 out of bound");

                            if (op2 >= maxValue) op2 = regs[op2 % maxValue];
                            if (op3 >= maxValue) op3 = regs[op3 % maxValue];

                            if (op2 == op3) regs[op1 % maxValue] = 1;
                            else regs[op1 % maxValue] = 0;

                            break;
                        case 5:
                            op1 = FetchByte();
                            op2 = FetchByte();
                            op3 = FetchByte();

                            if (!(op1 >= maxValue && op1 < bound))
                                throw new Exception($"Valore non valido per istruzione eq all'indirizzo {instr_addr}, op1 deve essere un registro");
                            if (op2 >= bound)
                                throw new Exception($"Valore non valido per istruzione eq all'indirizzo {instr_addr}, op2 out of bound");
                            if (op3 >= bound)
                                throw new Exception($"Valore non valido per istruzione eq all'indirizzo {instr_addr}, op3 out of bound");

                            if (op2 >= maxValue) op2 = regs[op2 % maxValue];
                            if (op3 >= maxValue) op3 = regs[op3 % maxValue];

                            if (op2 > op3) regs[op1 % maxValue] = 1;
                            else regs[op1 % maxValue] = 0;

                            break;

                        case 6: // jump op1
                            op1 = FetchByte();

                            if (op1 < bound)
                            {
                                if (op1 >= maxValue) PC = regs[op1 % maxValue];
                                else PC = op1;
                            }
                            else throw new Exception($"Valore non valido per istruzione jump all'indirizzo {instr_addr}, op1 out of bound");
                            break;

                        case 7: // jt op1, op2
                            op1 = FetchByte();
                            op2 = FetchByte();

                            if (op1 >= bound)
                                throw new Exception($"Valore non valido per istruzione jt all'indirizzo {instr_addr}, op1 out of bound");
                            if (op2 >= bound)
                                throw new Exception($"Valore non valido per istruzione jt all'indirizzo {instr_addr}, op2 out of bound");

                            if (op1 >= maxValue) op1 = regs[op1 % maxValue];
                            if (op2 >= maxValue) op2 = regs[op2 % maxValue];

                            if (op1 != 0) PC = op2;

                            break;

                        case 8: // jf op1, op2
                            op1 = FetchByte();
                            op2 = FetchByte();

                            if (op1 >= bound)
                                throw new Exception($"Valore non valido per istruzione jf all'indirizzo {instr_addr}, op1 out of bound");
                            if (op2 >= bound)
                                throw new Exception($"Valore non valido per istruzione jf all'indirizzo {instr_addr}, op2 out of bound");

                            if (op1 >= maxValue) op1 = regs[op1 % maxValue];
                            if (op2 >= maxValue) op2 = regs[op2 % maxValue];

                            if (op1 == 0) PC = op2;
                            break;

                        case 9:
                            op1 = FetchByte();
                            op2 = FetchByte();
                            op3 = FetchByte();

                            if (!(op1 >= maxValue && op1 < bound))
                                throw new Exception($"Valore non valido per istruzione add all'indirizzo {instr_addr}, op1 deve essere un registro");
                            if (op2 >= bound)
                                throw new Exception($"Valore non valido per istruzione add all'indirizzo {instr_addr}, op2 out of bound");
                            if (op3 >= bound)
                                throw new Exception($"Valore non valido per istruzione add all'indirizzo {instr_addr}, op3 out of bound");

                            if (op2 >= maxValue) op2 = regs[op2 % maxValue];
                            if (op3 >= maxValue) op3 = regs[op3 % maxValue];

                            regs[op1 % maxValue] = (ushort)((op2 + op3) % maxValue);

                            break;

                        case 10:
                            op1 = FetchByte();
                            op2 = FetchByte();
                            op3 = FetchByte();

                            if (!(op1 >= maxValue && op1 < bound))
                                throw new Exception($"Valore non valido per istruzione mult all'indirizzo {instr_addr}, op1 deve essere un registro");
                            if (op2 >= bound)
                                throw new Exception($"Valore non valido per istruzione mult all'indirizzo {instr_addr}, op2 out of bound");
                            if (op3 >= bound)
                                throw new Exception($"Valore non valido per istruzione mult all'indirizzo {instr_addr}, op3 out of bound");

                            if (op2 >= maxValue) op2 = regs[op2 % maxValue];
                            if (op3 >= maxValue) op3 = regs[op3 % maxValue];

                            regs[op1 % maxValue] = (ushort)((op2 * op3) % maxValue);

                            break;

                        case 11:
                            op1 = FetchByte();
                            op2 = FetchByte();
                            op3 = FetchByte();

                            if (!(op1 >= maxValue && op1 < bound))
                                throw new Exception($"Valore non valido per istruzione mod all'indirizzo {instr_addr}, op1 deve essere un registro");
                            if (op2 >= bound)
                                throw new Exception($"Valore non valido per istruzione mod all'indirizzo {instr_addr}, op2 out of bound");
                            if (op3 >= bound)
                                throw new Exception($"Valore non valido per istruzione mod all'indirizzo {instr_addr}, op3 out of bound");

                            if (op2 >= maxValue) op2 = regs[op2 % maxValue];
                            if (op3 >= maxValue) op3 = regs[op3 % maxValue];

                            if (op3 == 0) throw new DivideByZeroException($"Valore non valido per istruzione mod all'indirizzo {instr_addr}");

                            regs[op1 % maxValue] = (ushort)(op2 % op3);

                            break;

                        case 12:
                            op1 = FetchByte();
                            op2 = FetchByte();
                            op3 = FetchByte();

                            if (!(op1 >= maxValue && op1 < bound))
                                throw new Exception($"Valore non valido per istruzione and all'indirizzo {instr_addr}, op1 deve essere un registro");
                            if (op2 >= bound)
                                throw new Exception($"Valore non valido per istruzione and all'indirizzo {instr_addr}, op2 out of bound");
                            if (op3 >= bound)
                                throw new Exception($"Valore non valido per istruzione and all'indirizzo {instr_addr}, op3 out of bound");

                            if (op2 >= maxValue) op2 = regs[op2 % maxValue];
                            if (op3 >= maxValue) op3 = regs[op3 % maxValue];

                            regs[op1 % maxValue] = (ushort)(op2 & op3);

                            break;

                        case 13:
                            op1 = FetchByte();
                            op2 = FetchByte();
                            op3 = FetchByte();

                            if (!(op1 >= maxValue && op1 < bound))
                                throw new Exception($"Valore non valido per istruzione or all'indirizzo {instr_addr}, op1 deve essere un registro");
                            if (op2 >= bound)
                                throw new Exception($"Valore non valido per istruzione or all'indirizzo {instr_addr}, op2 out of bound");
                            if (op3 >= bound)
                                throw new Exception($"Valore non valido per istruzione or all'indirizzo {instr_addr}, op3 out of bound");

                            if (op2 >= maxValue) op2 = regs[op2 % maxValue];
                            if (op3 >= maxValue) op3 = regs[op3 % maxValue];

                            regs[op1 % maxValue] = (ushort)(op2 | op3);

                            break;

                        case 14:
                            op1 = FetchByte();
                            op2 = FetchByte();

                            if (!(op1 >= maxValue && op1 < bound))
                                throw new Exception($"Valore non valido per istruzione not all'indirizzo {instr_addr}, op1 deve essere un registro");
                            if (op2 >= bound)
                                throw new Exception($"Valore non valido per istruzione not all'indirizzo {instr_addr}, op2 out of bound");

                            if (op2 >= maxValue) op2 = regs[op2 % maxValue];

                            regs[op1 % maxValue] = (ushort)((~op2) & ((1 << 15) - 1));

                            break;

                        case 15:
                            op1 = FetchByte();
                            op2 = FetchByte();

                            if (!(op1 >= maxValue && op1 < bound))
                                throw new Exception($"Valore non valido per istruzione rmem all'indirizzo {instr_addr}, op1 deve essere un registro");
                            if (op2 >= bound)
                                throw new Exception($"Valore non valido per istruzione rmem all'indirizzo {instr_addr}, op2 out of bound");

                            if (op2 >= maxValue) op2 = regs[op2 % maxValue];

                            regs[op1 % maxValue] = RAM[op2];

                            break;

                        case 16:
                            op1 = FetchByte();
                            op2 = FetchByte();

                            if (op1 >= bound)
                                throw new Exception($"Valore non valido per istruzione wmem all'indirizzo {instr_addr}, op1 out of bound");
                            if (op2 >= bound)
                                throw new Exception($"Valore non valido per istruzione wmem all'indirizzo {instr_addr}, op2 out of bound");

                            if (op1 >= maxValue) op1 = regs[op1 % maxValue];
                            if (op2 >= maxValue) op2 = regs[op2 % maxValue];

                            RAM[op1] = op2;

                            break;

                        //call op1
                        case 17:
                            op1 = FetchByte();

                            if (op1 >= bound)
                                throw new Exception($"Valore non valido per istruzione call all'indirizzo {instr_addr}, op1 out of bound");

                            if (op1 >= maxValue) op1 = regs[op1 % maxValue];

                            stack.Push(PC);
                            PC = op1;

                            break;

                        case 18:

                            PC = stack.Pop();

                            break;

                        case 19: // out op1
                            op1 = FetchByte();

                            if (op1 >= bound) throw new Exception("valore invalido all'indirizzo " + instr_addr);

                            if (op1 >= maxValue)
                            {

                            Console.Write((char)regs[op1 % maxValue]);
                            WriteCharToFile((char)regs[op1 % maxValue]);
                             }
                            else
                                Console.Write((char)op1);
                                WriteCharToFile((char)op1);
                        break;

                        case 20: // in op1
                            op1 = FetchByte();

                            if (!(op1 >= maxValue && op1 < bound))
                            throw new Exception($"Valore non valido per istruzione in all'indirizzo {instr_addr}, op1 deve essere un registro");
                            PC = PC;
                            regs[op1 % maxValue] = (ushort)Console.Read();
                            if (regs[op1 % maxValue] == '\r') regs[op1 % maxValue] = '\n';
                            
                            break;

                        case 21: // nop
                            break;

                        default:
                            throw new Exception($"Istruzione {instr_code} non valida all'indirizzo {instr_addr}");
                    }
                }
            }
            static void WriteCharToFile(char c)
            {

                // Apre il file specificato per la scrittura
                using (StreamWriter writer = new StreamWriter(@"C:\Users\pietro.malzone\Desktop\ProcessorEmulator\JMP.txt", true))
                {
                // Scrive il testo nel file se viene effettuato un jump
                
                    if (c != '耀')
                    {
                        writer.Write(c);
                        writer.WriteLine();
                    }
                   



                
            }
        }
            static void LoadRAM(string file_name)
            {
                using (StreamReader sr = new StreamReader(file_name))
                {
                    for (int i = 0; !sr.EndOfStream && i < RAM.Length; ++i)
                    {
                        if (!ushort.TryParse(sr.ReadLine(), out RAM[i]))
                        {
                            throw new Exception($"Error parsng file '{file_name}' at line {i + 1}");
                        }
                    }
                    sr.Close();
                }
            }

            static void Main(string[] args)
            {
                ResetMachine();

                LoadRAM(@"..\..\..\challenge.txt");

                try
                {
                    RunMachine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
    