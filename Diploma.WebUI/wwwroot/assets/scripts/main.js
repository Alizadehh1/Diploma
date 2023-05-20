
document.querySelectorAll(".card-front input").forEach(x=>{
    x.addEventListener("mouseenter",function(){
        x.style.width="330px"
        x.style.padding="0px"
    })
})
document.querySelectorAll(".card-front input").forEach(x=>{
    x.addEventListener("mouseleave",function(){
        x.style.width="240px"
        x.style.padding="0px"
    })
})
document.querySelectorAll(".card-back input").forEach(x=>{
    x.addEventListener("mouseenter",function(){
        x.style.width="290px"
        x.style.padding="0px"
    })
})
document.querySelectorAll(".card-back input").forEach(x=>{
    x.addEventListener("mouseleave",function(){
        x.style.width="240px"
        x.style.padding="0px"
    })
})