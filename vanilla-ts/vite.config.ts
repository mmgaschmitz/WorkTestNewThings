// vite.config.js
import { defineConfig } from "vite";
export default () => {
  return defineConfig({
    build: {
      manifest: false,
      outDir: "buid",
      assetsDir: "static",
      rollupOptions: {
        output: {
          entryFileNames: `static/js/main.js`,
          // nexct :https://rollupjs.org/configuration-options/#output-chunkfilenames
        },
      },
    },
  });
};
