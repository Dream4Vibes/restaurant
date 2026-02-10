from fastapi import FastAPI
from pydantic import BaseModel
from typing import List, Optional
import mysql.connector
from mysql.connector import Error

# Создаем экземпляр приложения
app = FastAPI(title="Menu API")

# Описываем модель данных 
# Это нужно, чтобы FastAPI понимал, какие данные мы возвращаем
class FoodItem(BaseModel):
    name: str
    description: str
    price: float
    category: str
    portion: str
    is_available: bool = True  # Значение по умолчанию

def get_db_connection():
    try:
        connection = mysql.connector.connect(
            host = 'localhost',
            database = 'restoraunt',
            user = 'root',
            password = '1111'
        )
        if connection.is_connected():
            return connection
    except Error as e:
        print(f"Ошибка подключения к БД: {e}")
        return None

@app.get("/menu", response_model=List[FoodItem])
async def get_menu():
    """
    Возвращает список всех блюд из MySQL базы данных.
    """
    conn = get_db_connection()
    if conn is None:
        return [] # Если подключение не удалось, возвращаем пустой список

    menu_list = []
    cursor = None
    
    try:
        # Создаем курсор для выполнения запросов
        cursor = conn.cursor(dictionary=True) # dictionary=True вернет строки как словари
        
        # Выполняем SQL запрос
        cursor.execute("SELECT name, description, price, category, portion, is_available FROM restoraunt.disheas")
        
        # Получаем все строки
        rows = cursor.fetchall()
        
        # Преобразуем строки базы данных в объекты Pydantic
        for row in rows:
            # Decimal из MySQL нужно явно приводить к float для Pydantic
            item = FoodItem(
                name=row['name'],
                description=row['description'],
                price=float(row['price']),
                category=row['category'],
                portion=row['portion'],
                is_available=bool(row['is_available'])
            )
            menu_list.append(item)
            
    except Error as e:
        print(f"Ошибка при выполнении запроса: {e}")
    finally:
        # Закрываем соединение
        if cursor:
            cursor.close()
        if conn and conn.is_connected():
            conn.close()
            
            
    return menu_list


@app.post("/menu")
async def add_food_item(item: FoodItem):
    conn = get_db_connection()
    if conn is None:
        return {"error": "Не удалось подключиться к БД"}

    cursor = None
    try:
        cursor = conn.cursor()
        
        # SQL запрос на вставку данных
        # Порядок полей должен совпадать с БД
        query = """
            INSERT INTO restoraunt.disheas (name, description, price, category, portion, is_available) 
            VALUES (%s, %s, %s, %s, %s, %s)
        """
        
        # Формируем кортеж значений
        values = (item.name, item.description, item.price, item.category, item.portion, item.is_available)
        
        cursor.execute(query, values)
        conn.commit() # Фиксируем изменения
        
        return {"message": "Блюдо успешно добавлено в базу данных!"}
        
    except Error as e:
        return {"error": str(e)}
    finally:
        if cursor:
            cursor.close()
        if conn and conn.is_connected():
            conn.close()