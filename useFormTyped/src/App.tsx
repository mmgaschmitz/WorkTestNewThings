import { useForm, SubmitHandler } from "react-hook-form"


type InputsData = {
  example: string,
  exampleRequired: string,
  leeftijd: number
}


export default function App() {
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm<InputsData>()
  const onSubmit: SubmitHandler<InputsData> = (data) => console.log(data)


  console.log(watch("example")) // watch input value by passing the name of it


  return (
    /* "handleSubmit" will validate your inputs before invoking "onSubmit" */
    <form onSubmit={handleSubmit(onSubmit)}>
      {/* register your input into the hook by invoking the "register" function */}
      <input defaultValue="test" {...register("example")} />


      {/* include validation with required or other standard HTML validation rules */}
      <input {...register("exampleRequired", { required: true })} />
      {/* errors will return when field validation fails  */}

      <input defaultValue="10" {...register("leeftijd", {required: true, min: 25, max:90})}></input>

      <div>
      <h3>Errror's</h3>
      {errors.exampleRequired?.type === "required" && <p>This field is required</p>}
      {errors.leeftijd?.type === "required" && <p>This field is required</p>}
      {errors.leeftijd?.type === "min" && <p>Minimaal 25 jaar</p>}
      {errors.leeftijd?.type === "max" && <p>Maximale 90 jaar</p>}


      {errors.leeftijd && <span>{errors.leeftijd.message}</span>}
      </div>


      <input type="submit" />
    </form>
  )
}