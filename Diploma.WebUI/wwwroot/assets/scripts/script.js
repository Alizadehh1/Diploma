
const results = document.querySelector('#search-results');


var data = [{}];

const tableTr = document.querySelectorAll('#search-results tr');



for (var i = 0; i < tableTr.length; i++) {
    data[i] = {
        id: tableTr[i].children[0].textContent,
        Diplom: tableTr[i].children[1].textContent,
        Rəhbər: tableTr[i].children[2].textContent
    }
}

function gosterVeriler(veriler) {
    const html = [];

    veriler.forEach(item => {
        html.push(`
      <tr>
        <td data-label="No:">${item.id}</td>
        <td data-label="Diplom işi">${item.Diplom}</td>
        <td data-label="Rəhbər">${item.Rəhbər}</td>
        <td class="bs-checkbox" data-label="Seç">
          <input type="checkbox" onclick="myFunction1(this)" class="check" value="">
        </td>
      </tr>
    `);
    });

    results.innerHTML = html.join('');
}

//gosterVeriler(data);
const input = document.querySelector('#search-input');
input.addEventListener('input', () => {
    const deger = input.value.toLowerCase().trim();
    const filtreliVeriler = data.filter(item => item.Diplom.toLowerCase().includes(deger) || item.Rəhbər.toLowerCase().includes(deger));

    gosterVeriler(filtreliVeriler);
});





//function myFunction1(x) {
//    document.querySelectorAll('.check').forEach(y => {
//        if (y !== x) {
//            y.checked = false;

//        }
//    })
//}
//function myFunction2(x) {
//    document.querySelectorAll('.kcheck').forEach(y => {
//        if (y !== x) {
//            y.checked = false;

//        }
//    })
//}
//function myFunction3(x) {
//    document.querySelectorAll('.icheck').forEach(y => {
//        if (y !== x) {
//            y.checked = false;

//        }
//    })
//}

//function myFunction4(x) {
//    document.querySelectorAll('.rcheck').forEach(y => {
//        if (y !== x) {
//            y.checked = false;

//        }
//    })
//}
//function myFunction5(x) {
//    document.querySelectorAll('.fcheck').forEach(y => {
//        if (y !== x) {
//            y.checked = false;

//        }
//    })
//}
//function myFunction6(u) {
//    document.querySelectorAll('.ucheck').forEach(t => {
//        if (t !== u) {
//            t.checked = false;

//        }
//    })
//}