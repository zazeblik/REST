function loadBooks() {
    var books = [{
        "id": 1,
        "title": "qqqqq",
        "author": "qqqq"
    }, {
        "id": 2,
        "title": "www",
        "author": "www"
    }]
    renderTable(books);
}

function editBook() {
    var id = document.getElementById('editIdInput').value;
    if (!id) return;
    var title = document.getElementById('editTitleInput').value;
    var author = document.getElementById('editAuthorInput').value;
    // здесь будет код который будет редактировать книгу
    loadBooks();
}

async function deleteBook() {
    var id = document.getElementById('deleteIdInput').value;
    if (!id) return;
    // здесь будет код который будет удалять книгу
    loadBooks();
}

async function addBook() {
    var title = document.getElementById('addTitleInput').value;
    if (!title) return;
    var author = document.getElementById('addAuthorInput').value;
    // здесь будет код который будет добавлять книгу
    loadBooks();
}

function renderTable(books) {
    var tableBody = document.getElementById('tableBody');
    tableBody.innerHTML = '';
    books.forEach(bookInfo => {
        var tr = document.createElement('tr');
        appendTd(bookInfo.id, tr);
        appendTd(bookInfo.title, tr);
        appendTd(bookInfo.author, tr);
        tableBody.appendChild(tr);
    });
}

function appendTd(data, tr) {
    var td = document.createElement('td');
    td.appendChild(document.createTextNode(data || ""));
    tr.appendChild(td);
}

loadBooks();