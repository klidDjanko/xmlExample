using System;

namespace xmlExample
{
    class EduProgram
    {
        //Основная образовательная программа

        bool root; //корневая программа?
        string id; //идентификатор
        int code; //код
        int parentCode; //код родительской корневой программы
        string code2; //шифр
        string name; //имя образовательной программы

        public EduProgram(bool root, string id, string parentCode, string code, string code2, string name) 
        {
            this.root = root;
            this.id = id;
            this.code = Convert.ToInt32(code);
            this.code2 = code2;
            if (parentCode != "") this.parentCode = Convert.ToInt32(parentCode);
            this.name = name;
        }
    }
}
