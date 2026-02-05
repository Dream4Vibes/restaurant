import sys
from PySide6.QtWidgets import QApplication, QMainWindow, QMessageBox
from PySide6.QtCore import Qt, QAbstractTableModel
from PyForms.ui_main_form import Ui_MainWindow
from models.Food import Еда

     # Модель данных для таблицы меню
class MenuModel(QAbstractTableModel):
    def __init__(self,data):
        super().__init__()
        self._data = data
        self._headers = ["Категория","Название","Цена"]

    def rowCount(self,parent=None):
        return len(self._data)

    def columnCount(self, parent=None):
        return 3

    def data(self, index, role = Qt.DisplayRole):
        if role == Qt.DisplayRole:
            row = index.row()
            col = index.column()
            item = self._data[row]

            if col == 0:
                return item.категория
            elif col == 1:
                return item.название
            elif col == 2:
                return str(item.цена)  # Преобразуем цену в строку
        return None

    def headerData(self, section, orientation, role=Qt.DisplayRole):
        if role == Qt.DisplayRole and orientation == Qt.Horizontal:
            return self._headers[section]
        return None
    
    # Модель данных для таблицы корзины
class CartModel(QAbstractTableModel):
    def __init__(self):
        super().__init__()
        self._data = []  # Список кортежей: (блюдо, количество)
        self._headers = ["Название", "Кол-во", "Цена", "Сумма"]

    # Количество блюд в корзине
    def rowCount(self, parent=None):
        return len(self._data)

    # Количество столбцов (всегда 4)
    def columnCount(self, parent=None):
        return 4

    # Данные для отображения в корзине
    def data(self, index, role=Qt.DisplayRole):
        if role == Qt.DisplayRole:
            row = index.row()           # Номер строки
            col = index.column()        # Номер столбца
            item, count = self._data[row]  # Получаем блюдо и количество
            
            # Возвращаем данные в зависимости от столбца
            if col == 0:
                return item.название                # Название блюда
            elif col == 1:
                return str(count)                   # Количество порций
            elif col == 2:
                return str(item.цена)               # Цена за одну порцию
            elif col == 3:
                return str(item.цена * count)       # Общая стоимость
        return None

    # Заголовки столбцов корзины
    def headerData(self, section, orientation, role=Qt.DisplayRole):
        if role == Qt.DisplayRole and orientation == Qt.Horizontal:
            return self._headers[section]
        return None

    # Добавить блюдо в корзину
    def add_item(self, item, count):
        self._data.append((item, count))  # Добавляем кортеж (блюдо, количество)
        self.layoutChanged.emit()         # Сообщаем таблице об изменении данных

    # Удалить блюдо из корзины
    def remove_item(self, row):
        # Проверяем, что номер строки существует
        if 0 <= row < len(self._data):
            del self._data[row]          # Удаляем элемент по индексу
            self.layoutChanged.emit()    # Обновляем таблицу

    # Очистить всю корзину
    def clear(self):
        self._data.clear()               # Очищаем список
        self.layoutChanged.emit()        # Обновляем отображение


# Главное окно приложения
class MainWindow(QMainWindow):
    def __init__(self):
        super().__init__()
        
        # Загружаем интерфейс из файла
        self.ui = Ui_MainWindow()
        self.ui.setupUi(self)
        
        # Cписок блюд (объекты класса Еда)
        self.menu_items = [
            Еда("Салат Цезарь", "Курица, салат, сухарики", 450.0, "Закуска", "300 г"),
            Еда("Борщ", "Свекла, мясо, сметана", 350.0, "Суп", "400 мл"),
            Еда("Стейк Рибай", "Говядина, овощи", 1200.0, "Горячее", "350 г"),
            Еда("Тирамису", "Маскарпоне, кофе", 380.0, "Десерт", "150 г"),
            Еда("Кофе Латте", "Кофе, молоко", 250.0, "Напиток", "300 мл")
        ]
        
        # Настраиваем выпадающий список для выбора количества порций
        # Добавляем числа от 1 до 10
        for i in range(1, 11):
            self.ui.portsii.addItem(str(i))
        
        # Создаем модели данных для таблиц
        self.menu_model = MenuModel(self.menu_items)  # Модель для меню
        self.cart_model = CartModel()                 # Модель для корзины (изначально пустая)
        
        # Подключаем модели к таблицам
        self.ui.Menu.setModel(self.menu_model)    # Таблица меню
        self.ui.Korzina.setModel(self.cart_model) # Таблица корзины
        
        # Подключаем кнопки к функциям-обработчикам
        self.ui.Dobavit.clicked.connect(self.add_item)     # Кнопка "Добавить"
        self.ui.Udalit.clicked.connect(self.remove_item)   # Кнопка "Удалить"
        self.ui.Oformit.clicked.connect(self.place_order)  # Кнопка "Оформить"
        
        # При клике на блюдо в меню показываем его описание
        self.ui.Menu.clicked.connect(self.show_info)
    
    # Показать информацию о выбранном блюде
    def show_info(self, index):
        # Проверяем, что клик был по существующей строке
        if index.isValid():
            row = index.row()                # Получаем номер строки
            food = self.menu_items[row]      # Находим блюдо по индексу
            
            # Формируем текст с информацией
            text = f"Название: {food.название}\n"
            text += f"Категория: {food.категория}\n"
            text += f"Цена: {food.цена} руб.\n"
            text += f"Порция: {food.порция}\n"
            text += f"Описание: {food.описание}"
            
            # Отображаем текст в поле описания
            self.ui.Opisanie.setText(text)
    
    # Добавить блюдо в корзину
    def add_item(self):
        # Получаем текущую выбранную строку в меню
        index = self.ui.Menu.currentIndex()
        
        # Если ничего не выбрано - показываем ошибку
        if not index.isValid():
            QMessageBox.warning(self, "Ошибка", "Выберите блюдо!")
            return
        
        row = index.row()                    # Номер выбранной строки
        food = self.menu_items[row]          # Объект выбранного блюда
        
        # Проверяем наличие блюда
        if not food.наличие:
            QMessageBox.warning(self, "Ошибка", "Нет в наличии!")
            return
        
        # Получаем выбранное количество порций
        count = int(self.ui.portsii.currentText())
        
        # Добавляем блюдо в модель корзины
        self.cart_model.add_item(food, count)
    
    # Удалить блюдо из корзины
    def remove_item(self):
        # Получаем текущую выбранную строку в корзине
        index = self.ui.Korzina.currentIndex()
        
        # Если ничего не выбрано - показываем ошибку
        if not index.isValid():
            QMessageBox.warning(self, "Ошибка", "Выберите блюдо из корзины!")
            return
        
        row = index.row()  # Номер выбранной строки в корзине
        
        # Удаляем блюдо из модели корзины
        self.cart_model.remove_item(row)
    
    # Оформить заказ
    def place_order(self):
        # Проверяем, есть ли что-то в корзине
        if self.cart_model.rowCount() == 0:
            QMessageBox.warning(self, "Ошибка", "Корзина пуста!")
            return
        
        # Подсчет общей суммы заказа
        total = 0
        items_list = []  # Список для хранения строк заказа
        
        # Проходим по всем блюдам в корзине
        for i in range(self.cart_model.rowCount()):
            item, count = self.cart_model._data[i]  # Получаем блюдо и количество
            total += item.цена * count              # Добавляем к общей сумме
            items_list.append(f"{item.название} x{count}")  # Формируем строку
        
        # Формируем текст заказа
        order_text = "Ваш заказ:\n" + "\n".join(items_list) + f"\n\nИтого: {total:.2f} руб."
        
        # Показываем окно с информацией о заказе
        QMessageBox.information(self, "Заказ оформлен", order_text)
        
        # Очищаем корзину после оформления
        self.cart_model.clear()


# Точка входа в программу
if __name__ == "__main__":
    app = QApplication(sys.argv)
    window = MainWindow()
    window.setWindowTitle("Ресторан")
    window.show()
    sys.exit(app.exec())