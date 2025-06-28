#!/usr/bin/env python3
import random

def guess_the_number():
    number = random.randint(1, 100)
    attempts = 0

    print("Угадай число от 1 до 100!")

    while True:
        guess = int(input("Ваша попытка: "))
        attempts += 1

        if guess < number:
            print("Больше!")
        elif guess > number:
            print("Меньше!")
        else:
            print(f"Поздравляю! Вы угадали число за {attempts} попыток.")
            break
            
    guess_the_number()
