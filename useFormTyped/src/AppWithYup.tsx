import { useForm, SubmitHandler } from "react-hook-form"
import { yupResolver } from "@hookform/resolvers/yup"
import * as yup from "yup"

// https://strapi.io/blog/yup-validation-in-react-hook-form-a-complete-guide-with-examples

type InputsDataType = {
  example: string,
  exampleRequired: string,
  leeftijd: number
}

const myData: InputsDataType  = {
 example: "hello",
 exampleRequired: "en nog meer",
 leeftijd: 5
}

console.log(myData);

const InputsSchema = yup.object(
  {
    example: yup.string().trim().uppercase(),
    exampleRequired:  yup.string().required("A is verplicht").trim(),
    leeftijd: yup.number().required().min(10, "Mininmaal 10").max(60, "Maximaal 60"),
  }
);

// Validate to yup schema.
try
{
  InputsSchema.validate(myData);
}
catch(error)
{
  let message
	if (error instanceof Error) message = error.message
	else message = String(error)
  console.log(message);
}


// const TypeInputSchema =  yup.InferType<typeof InputsSchema>;

export default function App() {
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm<InputsDataType>()
  const onSubmit: SubmitHandler<InputsDataType> = (data) => console.log(data)


  console.log(watch("example")) // watch input value by passing the name of it


  return (
    /* "handleSubmit" will validate your inputs before invoking "onSubmit" */
    <form onSubmit={handleSubmit(onSubmit)}>
        <h3>Fields in a form</h3>
    
      <p>
        {/* register your input into the hook by invoking the "register" function */}
        <input defaultValue="test" {...register("example")} />
      </p>
        <p>
        {/* include validation with required or other standard HTML validation rules */}
        <input {...register("exampleRequired", { required: true })} />
        {/* errors will return when field validation fails  */}
      </p>
      <p>
        <input defaultValue="10" {...register("leeftijd", {required: true, min: 25, max:90})}></input>
      </p>
      <h3>Errror's</h3>
        {errors.exampleRequired?.type === "required" && <p>This field is required</p>}
        {errors.leeftijd?.type === "required" && <p>This field is required</p>}
        {errors.leeftijd?.type === "min" && <p>Minimaal 25 jaar</p>}
        {errors.leeftijd?.type === "max" && <p>Maximale 90 jaar</p>}
        {errors.leeftijd && <p>{errors.leeftijd.message}</p>}
      <input type="submit" />
    </form>
  )
}