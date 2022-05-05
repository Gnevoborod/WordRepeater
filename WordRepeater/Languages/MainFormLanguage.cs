using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordRepeater.Languages
{
    //по классу на каждую форму.
    class MainFormLanguage
    {
        public readonly string TITLE;
        public readonly string SETTINGS_BTN;
        public readonly string LANG_BTN;
        public readonly string WORD_BTN;
        public readonly string UPLOAD_BTN;
        public readonly string DOWNLOAD_BTN;
        public readonly string STATISTICS_BTN;
        public readonly string ABOUT_BTN;
        public readonly string QUIT_BTN;

        public readonly string APPROVE_TITLE;
        public readonly string APPROVE_TEXT;

        public readonly string PLACEHOLDER;
        public readonly string ONFORM_DELETE_BTN;
        public readonly string ONFORM_EDIT_BTN;

        public readonly string ACTIVE_REPEATING;
        public readonly string STATISTICS;


        public readonly string TOTAL;
        public readonly string WRONG;
        public readonly string RIGHT;
        public MainFormLanguage(int i)
        {
            TITLE = i==0
                ?"Repeating words"
                :"Повторение слов";
            SETTINGS_BTN = i == 0
                ? "Settings"
                : "Настройки";
            LANG_BTN = i == 0
                ? "Add new language"
                : "Добавить новый язык";
            WORD_BTN = i == 0
               ? "Add new word"
               : "Добавить новое слово";
            UPLOAD_BTN = i == 0
               ? "Load list of words"
               : "Загрузить список слов";
            DOWNLOAD_BTN = i == 0
               ? "Save all words"
               : "Сохранить все слова";
            STATISTICS_BTN = i == 0
               ? "Statistics"
               : "Статистика";
            ABOUT_BTN = i == 0
               ? "About"
               : "О программе";
            QUIT_BTN = i == 0
               ? "Quit"
               : "Выход";

            APPROVE_TITLE = i == 0
              ? "Quit approving"
              : "Подтверждение выхода";
            APPROVE_TEXT = i == 0
              ? "Do you want to stop trainee and quit?"
              : "Вы действительно хотите остановить тренировку и выйти";

            PLACEHOLDER = i == 0
              ? "Search"
              : "Поиск";

            ONFORM_DELETE_BTN = i == 0
              ? "Delete"
              : "Удалить";

            ONFORM_EDIT_BTN = i == 0
              ? "Edit"
              : "Правка";

            ACTIVE_REPEATING = i == 0
              ? "Repeat word"
              : "Повторять слово";

            STATISTICS = i == 0
              ? "Statistics"
              : "Статистика";
            TOTAL = i == 0
              ? "Total: "
              : "Всего: ";
            WRONG = i == 0
              ? "Wrong answers: "
              : "Ошибочных ответов: ";
            RIGHT = i == 0
              ? "Right answers: "
              : "Правильных ответов: ";

        }
    }
}
