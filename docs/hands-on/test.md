<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Full Page Responsive Image Grid with Amazing Animations</title>
    <script src="https://cdn.tailwindcss.com"></script>
    <style>
        html,
        body {
            height: 100%;
            margin: 0;
            padding: 0;
            overflow: hidden;
        }

        body {
            background: linear-gradient(135deg, #84fab0 0%, #8fd3f4 100%);
        }

        #grid {
            display: grid;
            height: 100vh;
            width: 100vw;
            grid-template-columns: repeat(4, 1fr);
            grid-template-rows: repeat(4, 1fr);
            gap: 1rem;
            padding: 1rem;
        }

        @media (max-width: 767px) {
            #grid {
                grid-template-columns: repeat(2, 1fr);
                grid-template-rows: repeat(4, 1fr);
            }
        }

        .grid-item {
            position: relative;
            overflow: hidden;
            border-radius: 1rem;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            transition: all 0.5s cubic-bezier(0.68, -0.55, 0.265, 1.55);
        }

        .grid-item:hover {
            transform: scale(1.05) rotate(2deg);
            box-shadow: 0 10px 20px rgba(0, 0, 0, 0.2);
            z-index: 10;
        }

        .grid-item img {
            width: 100%;
            height: 100%;
            object-fit: cover;
            transition: transform 0.5s ease-in-out;
        }

        .grid-item:hover img {
            transform: scale(1.1);
        }

        .grid-item .overlay {
            position: absolute;
            bottom: 0;
            left: 0;
            right: 0;
            background: rgba(0, 0, 0, 0.5);
            color: white;
            padding: 1rem;
            transform: translateY(100%);
            transition: transform 0.5s cubic-bezier(0.68, -0.55, 0.265, 1.55);
        }

        .grid-item:hover .overlay {
            transform: translateY(0);
        }

        @keyframes fadeInUp {
            from {
                opacity: 0;
                transform: translateY(20px);
            }

            to {
                opacity: 1;
                transform: translateY(0);
            }
        }

        .fade-in-up {
            animation: fadeInUp 0.8s ease-out backwards;
        }
    </style>
</head>

<body>
    <div id="grid">
        <!-- Grid items will be dynamically added here -->
    </div>

    <script>
        // a list of strings which were links
        const links = [
            'https://www.google.com',
            'https://www.facebook.com',
            'https://www.twitter.com',
            'https://www.linkedin.com'
        ];


        const grid = document.getElementById('grid');
        let imageCount = window.innerWidth < 768 ? 8 : 16;

        function createGridItem(index) {
            const item = document.createElement('div');
            item.className = 'grid-item fade-in-up';
            item.style.animationDelay = `${index * 0.1}s`;
            item.innerHTML = `
                <img src="https://picsum.photos/400/400?random=${index}" alt="Random image">
                <div class="overlay">
                    <a href="#" class="text-white hover:text-blue-300 transition duration-300">Link ${index + 1}</a>
                </div>
            `;
            return item;
        }

        function populateGrid() {
            grid.innerHTML = '';
            for (let i = 0; i < imageCount; i++) {
                grid.appendChild(createGridItem(i));
            }
        }

        populateGrid();

        window.addEventListener('resize', () => {
            const newImageCount = window.innerWidth < 768 ? 8 : 16;
            if (newImageCount !== imageCount) {
                imageCount = newImageCount;
                populateGrid();
            }
        });
    </script>
</body>

</html>
