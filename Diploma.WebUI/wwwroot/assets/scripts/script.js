const results = document.querySelector('#search-results');

const data = [
  {
      id : 1,
      Diplom : "Körpü tikintisi",
      Kateqoriya : "Memarlıq",
      Rəhbər:  "N.Süleymanov",
      img: 'https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8cmFuZG9tJTIwcGVvcGxlfGVufDB8fDB8fA%3D%3D&w=1000&q=80',
      Desc: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. "

  },
  {
      id : 2,
      Diplom : "Kiper Hücumlar",
      Kateqoriya : "İT",
      Rəhbər:  "R.Şahbazlı",
      img: 'https://images.unsplash.com/photo-1500648767791-00dcc994a43e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8cmFuZG9tJTIwcGVvcGxlfGVufDB8fDB8fA%3D%3D&w=1000&q=80',
      Desc:  "Duis quis porta odio. Integer ultrices ligula id eros vestibulum tempus. "

  },
  {
      id : 3,
      Diplom : "Bina Tikintisi",
      Kateqoriya : "Memarlıq",
      Rəhbər:  "R.Mahmudzadə",
      img: 'https://img.freepik.com/free-photo/young-man-with-beard-round-glasses_273609-6994.jpg?w=2000',
      Desc:  "Integer est augue, laoreet eu placerat et, fringilla eu nunc. "

  },
  {
      id : 4,
      Diplom : "Sistem-aparat işi",
      Kateqoriya : "İT",
      Rəhbər:  "İ.Kərimova",
      img: 'https://images.unsplash.com/photo-1438761681033-6461ffad8d80?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8cmFuZG9tJTIwcGVyc29ufGVufDB8fDB8fA%3D%3D&w=1000&q=80',
      Desc:  "Integer non massa elit. Donec id turpis vel mi tincidunt iaculis. "

  },
  {
      id : 5,
      Diplom : "Multimedia",
      Kateqoriya : "İT",
      Rəhbər:  "G.Səttərova",
      img: 'https://mir-s3-cdn-cf.behance.net/project_modules/2800_opt_1/15345c41332353.57a1ce9141249.jpg',
      Desc:  "Maecenas sollicitudin tempus metus, aliquet dignissim enim rhoncus non. "

  },
  {
      id : 6,
      Diplom : "Neft ixracı",
      Kateqoriya : "Neft-Qaz",
      Rəhbər:  "M.Abbaszadə",
      img: 'https://images.unsplash.com/photo-1463453091185-61582044d556?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8M3x8cmFuZG9tJTIwcGVyc29ufGVufDB8fDB8fA%3D%3D&w=1000&q=80',
      Desc:  "Vivamus eget libero rhoncus, varius nisi vel, accumsan nibh."

  }
]



function gosterVeriler(veriler) {
  const html = [];

  veriler.forEach(item => {
    html.push(`
      <tr>
        <td data-label="No:">${item.id}</td>
        <td data-label="Diplom işi">${item.Diplom}</td>
        <td data-label="Kateqoriya">${item.Kateqoriya}</td>
        <td data-label="Rəhbər">${item.Rəhbər}</td>
        <td data-label="Ətraflı">
          <button type="button" 
            id="${item.id}" 
            class="btn n-btn" onclick="myFunction(this)" 
            data-bs-toggle="modal"
            data-bs-target="#staticBackdrop">
            <i class="fa-duotone fa-book-open fa-beat fa-xl" 
              style="--fa-primary-color: #ffffff; --fa-secondary-color: #ffc800; --fa-secondary-opacity: 1;">
            </i>
          </button>
        </td>
        <td class="bs-checkbox" data-label="Seç">
          <input type="checkbox" onclick="myFunction1(this)" class="check" value="">
        </td>
      </tr>
    `);
  });

  results.innerHTML = html.join('');
}

gosterVeriler(data);
const input = document.querySelector('#search-input');
input.addEventListener('input', () => {
  const deger = input.value.toLowerCase().trim();
  const filtreliVeriler = data.filter(item => item.Diplom.toLowerCase().includes(deger));
  
  gosterVeriler(filtreliVeriler);
});



function myFunction(x){
  data.forEach(y=>{
    if(y.id==x.id){
      document.querySelector('.modal-body').innerHTML=`
      
      
      
      <div class="row">
      <div class="col-md-12 d-flex justify-content-center align-items-center"><h3 class="text-white" >${y.Diplom}</h3></div>
      <div class="col-md-3  d-flex  flex-column align-items-center justify-content-around gap-3 "><img class="personality" src="${y.img}" alt="">
      <p class="text-white" >${y.Rəhbər}</p>
      </div>
      <div class="col-md-9 d-flex  mt-3 "> <p class="text-white desc" >${y.Desc}</p></div>
    </div>`
    }
  })
}

function myFunction1(x){
  document.querySelectorAll('.check').forEach(y=>{
    if (y !== x) {
      y.checked = false;
      
  }
  })
}
function myFunction2(x){
  document.querySelectorAll('.kcheck').forEach(y=>{
    if (y !== x) {
      y.checked = false;
      
  }
  })
}
function myFunction3(x){
  document.querySelectorAll('.icheck').forEach(y=>{
    if (y !== x) {
      y.checked = false;
      
  }
  })
}

function myFunction4(x){
  document.querySelectorAll('.rcheck').forEach(y=>{
    if (y !== x) {
      y.checked = false;
      
  }
  })
}
function myFunction5(x){
  document.querySelectorAll('.fcheck').forEach(y=>{
    if (y !== x) {
      y.checked = false;
      
  }
  })
}
function myFunction6(u){
  document.querySelectorAll('.ucheck').forEach(t=>{
    if (t !== u) {
      t.checked = false;
      
  }
  })
}