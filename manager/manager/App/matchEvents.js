﻿define([], function () {
    return {
        getStartStopEvent: function (index) {
            switch (index) {
                case 0:
                    return 'Начало матча';
                case 1:
                    return 'Конец первого тайма';
                case 2:
                    return 'Начало второй тайма';
                case 3:
                    return 'Конец матча';
            }
            return '';
        },
        getMidfieldPasses: function (line) {
            return 'Перепасовка в центре поля между {' + line[0] + ',0}, {' + line[1] + ',1} и {' + line[2] + ',2} без продвижения вперед';
        },
        getTryToDribbling: function (line, flag) {
            if (flag == 2)
                return '{' + line[0] + ',0} отдал пас на {' + line[1] + ',1} и тот потерял мяч. {' + line[2] + ',2} сыграл хорошо и начал атаку своей команды';
            if (flag == 3)
                return '{' + line[1] + ',1} отдал пас на {' + line[2] + ',2} и тот потерял мяч. {' + line[3] + ',3} сыграл хорошо и начал атаку своей команды';
            return 'Попытка отдать пас {' + line[0] + ',0} завершилась неудачей. {' + line[1] + ',1} сыграл хорошо и отобрал мяч';
        },
        getPasThenStrikeTwoCautch: function (line, flag) {
            if (flag == 2)
                return '{' + line[1] + ',1} отдал пас на {' + line[2] + ',2} и тот пробил с дальней дистанции, но {' + line[3] + ',3} поймал этот матч';
            return '{' + line[0] + ',0} отдал пас на {' + line[1] + ',1} и тот пробил с дальней дистанции, но {' + line[2] + ',2} поймал этот матч';
        },
        getPasThenStrikeOneCautch: function (line, flag) {
            if (flag == 2)
                return '{' + line[1] + ',1} отдал пас на {' + line[2] + ',2} и тот пробил, но {' + line[3] + ',3} поймал этот матч';
            return '{' + line[0] + ',0} отдал пас на {' + line[1] + ',1} и тот пробил, но {' + line[2] + ',2} поймал этот матч';
        },
        getStrikeTwoCautch: function (line) {
            return '{' + line[0] + ',0} неожиданно пробил издалека, но {' + line[1] + ',1} был на месте и среагировал на этот удар';
        },
        getStrikeOneGoal: function (line, flag) {
            if (flag == 2)
                return 'ГОООЛ! {' + line[1] + ',1} отдал пас на {' + line[2] + ',2} и тот сразу пробил по воротам без шансов для вратаря';
            if (flag == 3)
                return 'ГОООЛ! {' + line[2] + ',2} отличным пасом вывел {' + line[3] + ',3} 1 на 1 и форвард сразу пробил мимо вратаря';
            return 'ГОООЛ! {' + line[0] + ',0} отдал пас на {' + line[1] + ',1} и тот сразу пробил по воротам без шансов для вратаря';
        },
        getStrikeTwoGoal: function (line, flag) {
            if (flag == 2)
                return 'ГОООЛ! {' + line[0] + ',0} отдал пас на {' + line[1] + ',1} и тот пробил издалека без шансов для вратаря';
            if (flag == 3)
                return 'ГОООЛ! {' + line[1] + ',1} отдал пас на {' + line[2] + ',2} и тот пробил издалека без шансов для вратаря';
            return 'ГОООЛ! {' + line[0] + ',0} решил пробить с дальней дистанции и у него вышел отличный удар';
        },
        getTryPasAndFoul: function (line, flag) {
            if (flag == 2)
                return 'Борьба в центре поля между {' + line[1] + ',1} и {' + line[2] + ',2} и нарушение со стороны последнего. Штрафной удар.';
            return 'Борьба в центре поля между {' + line[0] + ',0} и {' + line[1] + ',1} и нарушение со стороны последнего. Штрафной удар.';
        },
        getForwardPasFail: function (line, flag) {
            if (flag == 4)
                return '{' + line[3] + ',3} хорошо отпасовал вперед, но {' + line[4] + ',4} потерял мяч';
            if (flag == 3)
                return '{' + line[2] + ',2} хорошо отпасовал вперед, но {' + line[3] + ',3} потерял мяч';
            if (flag == 2)
                return '{' + line[1] + ',1} хорошо отпасовал вперед, но {' + line[2] + ',2} потерял мяч';
            return '{' + line[0] + ',0} хорошо отпасовал вперед, но {' + line[1] + ',1} потерял мяч';
        },
        getForwardPasAnyware: function (line, flag) {
            if (flag == 2)
                return '{' + line[1] + ',1} и {' + line[2] + ',2} вывели {' + line[3] + ',3} на ударную позицию, но тот игрыл плохо и потерял мяч';
            return '{' + line[0] + ',0} и {' + line[1] + ',1} вывели {' + line[2] + ',2} на ударную позицию, но тот игрыл плохо и потерял мяч';
        },
        yellowForDefender: function (line, flag) {
            if (flag == 3)
                return 'Желтая карточка для {' + line[3] + ',3} за нарушение против {' + line[2] + ',2}';
            if (flag == 2)
                return 'Желтая карточка для {' + line[2] + ',2} за нарушение против {' + line[1] + ',1}';
            return 'Желтая карточка для {' + line[1] + ',1} за нарушение против {' + line[0] + ',0}';
        },
        redForDefender: function (line, flag) {
            if (flag == 3)
                return 'Красная карточка для {' + line[4] + ',4} за нарушение против {' + line[2] + ',2}';
            if (flag == 2)
                return 'Красная карточка для {' + line[3] + ',3} за нарушение против {' + line[1] + ',1}';
            return 'Красная карточка для {' + line[2] + ',2} за нарушение против {' + line[0] + ',0}';
        },
        OneOnOneStrikeCautch: function (line) {
            return '{' + line[1] + ',1} выводит {' + line[2] + ',2} один на один с вратарем. Удар! {' + line[4] + ',4} ловит этот мяч';
        },
        ForwardBeatSave: function (line) {
            return '{' + line[1] + ',1} вывел {' + line[2] + ',2} 1 на 1 с вратарем. Форвард пошел в обыгрыш, но {' + line[4] + ',4} сыграл хорошо и отобрал мяч';
        },
        CornerCautch: function (line) {
            return 'После подачи уголового {' + line[3] + ',3} наносил удар, но {' + line[4] + ',4} поймал этот мяч';
        },
        OneOnOneThenCornerCauth: function (line, flag) {
            if (flag == 2)
                return '{' + line[2] + ',2} бил по воротам и заработал угловой, который подали прямо в руки {' + line[4] + ',4}';
            if (flag == 1)
                return '{' + line[1] + ',1} бил по воротам и заработал угловой, который подали прямо в руки {' + line[3] + ',3}';
            return '{' + line[0] + ',0} бил по воротам и заработал угловой, который подали прямо в руки {' + line[2] + ',2}';
        },
        PenaltyCaught: function (line) {
            return 'Пенальти! {' + line[2] + ',2} против {' + line[3] + ',3}. Удар! Голкипер намертво берет этот мяч';
        },
        OneOneGoal: function (line, flag) {
            if (flag == 2)
                return 'ГОООЛ! {' + line[2] + ',2} выходит 1 на 1 с вратарем, обыгрывает его и закатывает мяч в пустые ворота';
            return 'ГОООЛ! {' + line[1] + ',1} выходит 1 на 1 с вратарем, обыгрывает его и закатывает мяч в пустые ворота';
        }
    };
})